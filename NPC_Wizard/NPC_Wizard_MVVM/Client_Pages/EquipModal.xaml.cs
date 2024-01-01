using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System;
using NPC_Wizard_MVVM.Object_Classes;

namespace NPC_Wizard_MVVM.Client_Pages
{
    public partial class EquipModal : Window, INotifyPropertyChanged
    {
        private List<string> _displayList = new List<string> { "Please wait, Loading data..." };
        public event EventHandler<string> ItemSelected;

        public List<string> DisplayList
        {
            get { return _displayList; }
            set
            {
                _displayList = value;
                OnPropertyChanged();
            }
        }

        public EquipModal()
        {
            InitializeComponent();
            _ = LoadSearchAsync();
            DataContext = this; // Set DataContext for data binding

            // Don't need to check if loadSearch is null, and no need to manually add items to ProfList
        }

        public async Task LoadSearchAsync()
        {
            ItemUI itemUI = new();
            DisplayList = await itemUI.GetEquipNamesAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ProfList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void ConfirmBtn_Click(object sender, RoutedEventArgs e)
        {

            if (EquipList.SelectedItem != null)
            {

                string selectedProf = EquipList.SelectedItem.ToString();
                if (GlobalVariables.CurrentEquipment == null)
                {
                    GlobalVariables.CurrentEquipment = new List<string>();
                }
                GlobalVariables.CurrentEquipment.Add(selectedProf);
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
