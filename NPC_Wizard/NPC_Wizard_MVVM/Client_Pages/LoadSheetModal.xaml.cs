using NPC_Wizard_MVVM.Object_Classes;
using NPC_Wizard_MVVM.viewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NPC_Wizard_MVVM.Client_Pages
{
    /// <summary>
    /// Interaction logic for LoadSheetModal.xaml
    /// </summary>
    public partial class LoadSheetModal : Window
    {
        private List<string> _displayList = new List<string> { "Please wait, Loading data..." };
        public LoadSheetModal()
        {
            InitializeComponent();
            DataContext = this; // Set DataContext for data binding
            DisplayList = getAllCharacterNames();
        }

        public List<string> DisplayList
        {
            get { return _displayList; }
            set
            {
                _displayList = value;
                //OnPropertyChanged();
            }
        }

        private void loadBtnClick(object sender, RoutedEventArgs e)
        {
            if(SheetList.SelectedItem != null)
            {
                DialogResult = true; // This will close the modal with a positive result
                string selectedCharacter = SheetList.SelectedItem.ToString();

                // Now 'selectedCharacter' contains the selected item from the list
                Debug.WriteLine($"Selected Character: {selectedCharacter}");

                foreach (var item in GlobalVariables.AllCharacters)
                {
                    //Debug.WriteLine(item.CharacterName + " " + selectedCharacter) ;
                    if (item.CharacterName == selectedCharacter)
                    {
                        // Do something with the selected character
                        Debug.WriteLine("Yes Selected character");
                        GlobalVariables.selectedCharacter = item;
                        GlobalVariables.isEditMode = true;
                        GlobalVariables.sheetbuilderData?.Clear();
                        
                        //switch to sheetbuilder
                        MainViewModel mainViewModel = (Application.Current.MainWindow as MainWindow)?.DataContext as MainViewModel;
                        mainViewModel?.UpdateViewCommand.Execute(typeof(SheetBuilderViewModel));


                    }
                }
            }
        }

        private List<string> getAllCharacterNames() { 
            List<string> names = new List<string>();
            if (GlobalVariables.AllCharacters.Count > 0)
            { 
                for (int i = 0; i < GlobalVariables.AllCharacters.Count; i++)
                {
                    if (GlobalVariables.AllCharacters[i].CharacterName.Length >= 1)
                    { 
                         names.Add(GlobalVariables.AllCharacters[i].CharacterName);
                    }
                }
            }
            
            return names;
        }
    }
}
