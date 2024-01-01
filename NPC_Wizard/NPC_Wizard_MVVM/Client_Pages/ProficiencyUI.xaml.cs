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
    /// Interaction logic for ProficiencyUI.xaml
    /// </summary>
    public partial class ProficiencyUI : UserControl, INotifyPropertyChanged
    {
        //This was an attempt to use a view model to test the layout. I'm just going to create a list
        //or something with fake data to test my layout instead. --@Matt


        private static readonly string PROF_API_URL = "https://www.dnd5eapi.co/api/proficiencies";
        private ProficiencyUIViewModel viewModel;

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
        


        public ProficiencyUI()
        {
            InitializeComponent();
            viewModel = new ProficiencyUIViewModel();
            DataContext = viewModel;
            viewModel.SelectedDataSTRING = new ObservableCollection<string>();
            if (GlobalVariables.CurrentProficiencies != null)
            {
                foreach (var item in GlobalVariables.CurrentProficiencies)
                {
                    viewModel.SelectedDataSTRING.Add(item);
                }
            }

        // Uncomment if you want the list populated with all proficiencies
        //PopulateListWithAPIAsync();
    }

        //public async Task PopulateListWithAPIAsync()
        //{           

        //    ProficiencyAPIResponse result = await GetJsonFromApiAsync<ProficiencyAPIResponse>("https://www.dnd5eapi.co/api/proficiencies");            

        //}

        private async Task<List<string>> LoadProfNamesFromAPIAsync(string url)
        {
            List<string> profNames = new List<string>();

            ProficiencyAPIResponse result = await GetJsonFromApiAsync<ProficiencyAPIResponse>(url);

            if (result != null && result.results != null)
            {
                profNames.AddRange(result.results.Select(proficiency => proficiency.name));
            }

             
            return profNames;
        }

        public async Task<List<string>> GetProfNamesAsync()
        {
            return await LoadProfNamesFromAPIAsync(PROF_API_URL);
        }

       
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            ProfModal profModal = new ProfModal();
            Window parentWindow = Window.GetWindow(this);
            if(parentWindow != null)
            {
                profModal.Owner = parentWindow;
            }
            profModal.ItemSelected += ProfModal_ItemSelected;
            profModal.ShowDialog();
            


        }
        private void ProfModal_ItemSelected(object sender, string selectedProf)
        {

            // Handle the selected item in ProficiencyUI
            viewModel.SelectedDataSTRING.Add(selectedProf); 

            

        }

        private void ProfList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handle the selection change event
            if (profList.SelectedItem != null)
            {
                string selectedProf = profList.SelectedItem.ToString();
                Debug.WriteLine($"Selected item: {selectedProf}");
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
                    string sProf = profList.SelectedItem?.ToString();
                    viewModel.SelectedDataSTRING.Remove(sProf);
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

    public class ListData
    {
        public String Name { get; set; }
        public String Description { get; set; }
    }

    class Proficiency
    {
        public string index;
        public string name;
        public string url;

        public Proficiency(string name, string index, string url)
        {
            this.name = name;
            this.index = index;
            this.url = url;
        }

        public Proficiency()
        {
            this.name = "";
            this.index = "";
            this.url = "";
        }
    }

    class ProficiencyAPIResponse
    {
        public int count { get; set; }
        public List<Proficiency> results { get; set; }
    }
}
