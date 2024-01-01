using NPC_Wizard;
using NPC_Wizard_MVVM.databaseFiles;
using NPC_Wizard_MVVM.Object_Classes;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NPC_Wizard_MVVM.Client_Pages
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : UserControl
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            LoadSheetModal loadModal = new LoadSheetModal();
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null)
            {
                loadModal.Owner = parentWindow;
            }
            
            loadModal.ShowDialog();



        }

        private void NewBtn_Click(object sender, RoutedEventArgs e)
        { 
            GlobalVariables.sheetbuilderData?.Clear();
            GlobalVariables.CurrentProficiencies?.Clear();
            GlobalVariables.CurrentEquipment?.Clear();
            GlobalVariables.CurrentSpells?.Clear();
        }
    }
}
