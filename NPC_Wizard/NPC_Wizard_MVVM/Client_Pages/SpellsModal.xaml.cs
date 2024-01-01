using Newtonsoft.Json;
using NPC_Wizard_MVVM.Object_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for SpellsModal.xaml
    /// </summary>
    public partial class SpellsModal : Window, INotifyPropertyChanged
    {
        private List<ListDataSpells> _displayList = new List<ListDataSpells> { new ListDataSpells { Name = "Please wait, Loading data..." } };
        public event EventHandler<ListDataSpells> ItemSelected;

        public List<ListDataSpells> DisplayList
        {
            get { return _displayList; }
            set
            {
                _displayList = value;
                OnPropertyChanged();
            }
        }


        public SpellsModal()
        {
            InitializeComponent();
            _ = LoadSearchAsync();
            DataContext = this; // Set DataContext for data binding
        }
        public async Task LoadSearchAsync()
        {
            SpellsUI su = new();
            DisplayList = await su.GetSpellsDetailsAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

     

        private void ConfirmBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ProfList.SelectedItem != null)
            {
                ListDataSpells selectedProf = (ListDataSpells)ProfList.SelectedItem;
                if (GlobalVariables.CurrentSpells == null)
                {
                    GlobalVariables.CurrentSpells = new List<ListDataSpells>();
                }
                GlobalVariables.CurrentSpells.Add(selectedProf);
                ItemSelected?.Invoke(this, selectedProf);
                DialogResult = true; // This will close the modal with a positive result
            }
            else
            {
                // Optionally handle the case where nothing is selected
                MessageBox.Show("Please select a proficiency before confirming.", "Selection Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



       

    }
}

