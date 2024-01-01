using Newtonsoft.Json;
using NPC_Wizard_MVVM.Object_Classes;
using NPC_Wizard_MVVM.viewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NPC_Wizard_MVVM.Client_Pages
{
    /// <summary>
    /// Interaction logic for ItemUI.xaml
    /// </summary>
    public partial class ItemUI : UserControl, INotifyPropertyChanged
    {
        //This was an attempt to use a view model to test the layout. I'm just going to create a list
        //or something with fake data to test my layout instead. --@Matt


        private static readonly string EQUIP_API_URL = "https://www.dnd5eapi.co/api/equipment";
        private ItemViewModel viewModel;

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private void NotifyPropertyChanged(string propertyName)
        {
            OnPropertyChanged(propertyName);
        }

        public List<ListData> data { get; set; }



        public ItemUI()
        {
            InitializeComponent();
            viewModel = new ItemViewModel();
            DataContext = viewModel;
            viewModel.SelectedDataSTRING = new ObservableCollection<string>();
            if (GlobalVariables.CurrentEquipment != null)
            {
                foreach (var item in GlobalVariables.CurrentEquipment)
                {
                    viewModel.SelectedDataSTRING.Add(item);
                }
            }

        }

        

        private async Task<List<string>> LoadEquipNamesFromAPIAsync(string url)
        {
            List<string> equipNames = new List<string>();

            EquipmentAPIResponse result = await GetJsonFromApiAsync<EquipmentAPIResponse>(url);

            if (result != null && result.results != null)
            {
                equipNames.AddRange(result.results.Select(equipment => equipment.name));
            }


            return equipNames;
        }

        public async Task<List<string>> GetEquipNamesAsync()
        {
            return await LoadEquipNamesFromAPIAsync(EQUIP_API_URL);
        }


        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EquipModal equipModal = new();
                Window parentWindow = Window.GetWindow(this);
                if (parentWindow != null)
                {
                    equipModal.Owner = parentWindow;
                }
                equipModal.ItemSelected += EquipModal_ItemSelected;
                equipModal.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void EquipModal_ItemSelected(object sender, string selectedEquip)
        {

            // Handle the selected item in ItemUI
            viewModel.SelectedDataSTRING.Add(selectedEquip);



        }

        private void EquipList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handle the selection change event
            if (EquipList.SelectedItem != null)
            {
                string selectedEquip = EquipList.SelectedItem.ToString();
                Debug.WriteLine($"Selected item: {selectedEquip}");
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button deleteButton = sender as Button;

                // Get the ListBoxItem that contains the Delete button
                ListBoxItem listBoxItem = FindAncestor<ListBoxItem>(deleteButton);

                if (listBoxItem != null)
                {
                    // Set the ListBox selection to the clicked item
                    listBoxItem.IsSelected = true;

                    // Remove the selected item from viewModel.SelectedDataSTRING
                    string sEquip = EquipList.SelectedItem?.ToString();
                    viewModel.SelectedDataSTRING.Remove(sEquip);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Helper method to find the parent ListBoxItem of a UIElement
        private T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            do
            {
                if (current is T ancestor)
                {
                    return ancestor;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);

            return null;
        }


        static async Task<T> GetJsonFromApiAsync<T>(string url)
        {
            string apiUrl = url;

            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonContent = await response.Content.ReadAsStringAsync();

                        // Deserialize the JSON string into the specified generic type
                        return JsonConvert.DeserializeObject<T>(jsonContent);
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }
            }
            return default;
        }

    }

    public class EquipListData
    {
        public String Name { get; set; }
        public String Description { get; set; }
    }

    class Equipment
    {
        public string index;
        public string name;
        public string url;

        public Equipment(string name, string index, string url)
        {
            this.name = name;
            this.index = index;
            this.url = url;
        }

        public Equipment()
        {
            this.name = "";
            this.index = "";
            this.url = "";
        }
    }

    class EquipmentAPIResponse
    {
        public int count { get; set; }
        public List<Equipment> results { get; set; }
    }
}
