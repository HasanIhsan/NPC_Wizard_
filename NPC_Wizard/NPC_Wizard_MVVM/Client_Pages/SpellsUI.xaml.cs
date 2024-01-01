using NPC_Wizard_MVVM.viewModels;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using System.Diagnostics;
using NPC_Wizard_MVVM.Object_Classes;

namespace NPC_Wizard_MVVM.Client_Pages
{
    /// <summary>
    /// Interaction logic for SpellsUI.xaml
    /// </summary>
    public partial class SpellsUI : UserControl
    {
        private static readonly string SPELLS_API_URL = "https://www.dnd5eapi.co/api/spells";
        private SpellsUIViewModel viewModel;

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private void NotifyPropertyChanged(string propertyName)
        {
            OnPropertyChanged(propertyName);
        }

        public List<ListDataSpells> data { get; set; }
        public SpellsUI()
        {
            InitializeComponent();
            InitializeComponent();
            viewModel = new SpellsUIViewModel();
            DataContext = viewModel;
            viewModel.SelectedDataSTRING = new ObservableCollection<ListDataSpells>();
            if (GlobalVariables.CurrentSpells != null)
            {
                foreach (var item in GlobalVariables.CurrentSpells)
                {
                    viewModel.SelectedDataSTRING.Add(item);
                }
            }

            //populateList();
        }


        private async Task<List<ListDataSpells>> LoadSpellsDetailsFromAPIAsync(string url)
        {
            List<ListDataSpells> spellList = new List<ListDataSpells>();

            SpellAPIResponse result = await GetJsonFromApiAsync<SpellAPIResponse>(url);

            if (result != null && result.results != null)
            {
                foreach (var spell in result.results)
                {
                    ListDataSpells listData = new ListDataSpells
                    {
                        Name = spell.name,
                        Level = -1, // Level is not fetched initially
                        SpellIndex = spell.index
                    };
                    spellList.Add(listData);
                }
            }

            return spellList;
        }


        public async Task<List<ListDataSpells>> GetSpellsDetailsAsync()
        {
            return await LoadSpellsDetailsFromAPIAsync(SPELLS_API_URL);
        }


        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            SpellsModal spellModal = new SpellsModal();
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null)
            {
                spellModal.Owner = parentWindow;
            }
            spellModal.ItemSelected += SpellsModal_ItemSelected;
            spellModal.ShowDialog();


        }

        private async void SpellsModal_ItemSelected(object sender, ListDataSpells selectedSpell)
        {

            Debug.WriteLine(SPELLS_API_URL + "/" + selectedSpell.SpellIndex);

            SpellDetails spellDetails = await GetJsonFromApiAsync<SpellDetails>(SPELLS_API_URL + "/" + selectedSpell.SpellIndex);
            selectedSpell.Level = spellDetails.level;


            Debug.WriteLine(selectedSpell.Level);

            viewModel.SelectedDataSTRING.Add(selectedSpell);

        }





        private void SpellsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handle the selection change event
            if (spellsList.SelectedItem != null)
            {
                string selectedSpell = spellsList.SelectedItem.ToString();
                Debug.WriteLine($"Selected item: {selectedSpell}");
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
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

                        Debug.WriteLine(jsonContent);

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

    public class ListDataSpells
    {
        public String Name { get; set; }
        public int Level { get; set; }
        public string SpellIndex { get; set; }


        // Add a property for a formatted display string
        public string DisplayString => $"{Level} \t\t {Name}";
    }

    class Spell
    {
        public string index;
        public string name;
        public string url;

        public Spell(string name, string index, string url)
        {
            this.name = name;
            this.index = index;
            this.url = url;
        }

        public Spell()
        {
            this.name = "";
            this.index = "";
            this.url = "";
        }
    }

    class SpellAPIResponse
    {
        public int count { get; set; }
        public List<Spell> results { get; set; }
    }


    class SpellDetails
    {
        public string index { get; set; }
        public string name { get; set; }
        public List<string> desc { get; set; }
        public List<string> higher_level { get; set; }
        public string range { get; set; }
        public List<string> components { get; set; }
        public string material { get; set; }
        public bool ritual { get; set; }
        public string duration { get; set; }
        public bool concentration { get; set; }
        public string casting_time { get; set; }
        public int level { get; set; }
        public string attack_type { get; set; }
        public DamageDetails damage { get; set; }
        public SchoolDetails school { get; set; }
        public List<ClassDetails> classes { get; set; }
        public List<SubclassDetails> subclasses { get; set; }
        public string url { get; set; }
    }

    class DamageDetails
    {
        public DamageTypeDetails damage_type { get; set; }
        public Dictionary<string, string> damage_at_slot_level { get; set; }
    }

    class DamageTypeDetails
    {
        public string index { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }

    class SchoolDetails
    {
        public string index { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }

    class ClassDetails
    {
        public string index { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }

    class SubclassDetails
    {
        public string index { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }
}
