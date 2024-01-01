using MongoDB.Bson;
using NPC_Wizard;
using NPC_Wizard_MVVM.databaseFiles;
using NPC_Wizard_MVVM.Object_Classes;
using NPC_Wizard_MVVM.viewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    /// Interaction logic for SheetBuilder.xaml
    /// </summary>
    public partial class SheetBuilder : UserControl
    {
        

        public SheetBuilder()
        {
            InitializeComponent();

           


            //check if allcharacters in the global vars has values
            Debug.WriteLine(GlobalVariables.AllCharacters.Count());
            Debug.WriteLine(GlobalVariables.sheetbuilderData.Count());


           
            

            //show saved data in the sheetbuilderdata
            if(GlobalVariables.sheetbuilderData.Count() > 0)
            {
                cName_txt.Text = GlobalVariables.sheetbuilderData[0].characterName;
                pName_txt.Text = GlobalVariables.sheetbuilderData[0].playerName;

                sizeCmb.Text = GlobalVariables.sheetbuilderData[0].size.ToString();

                hp_txt.Text = GlobalVariables.sheetbuilderData[0].hp.ToString();
                raceCmb.Text = GlobalVariables.sheetbuilderData[0].raceName;
                class_txt.Text = GlobalVariables.sheetbuilderData[0].characterClass;
                LvlCmb.Text = GlobalVariables.sheetbuilderData[0].level.ToString();
                typeCmb.Text = GlobalVariables.sheetbuilderData[0].type;

                if (GlobalVariables.sheetbuilderData[0].abilityScore.TryGetValue("Strength", out int strValue))
                {
                    strBox.Text = strValue.ToString();
                }

                if (GlobalVariables.sheetbuilderData[0].abilityScore.TryGetValue("Dexterity", out int dexValue))
                {
                    dexBox.Text = dexValue.ToString();
                }
                if (GlobalVariables.sheetbuilderData[0].abilityScore.TryGetValue("Constitution", out int conValue))
                {
                    conBox.Text = conValue.ToString();
                }
                if (GlobalVariables.sheetbuilderData[0].abilityScore.TryGetValue("Intelligence", out int intValue))
                {
                    intBox.Text = intValue.ToString();
                }
                if (GlobalVariables.sheetbuilderData[0].abilityScore.TryGetValue("Wisdom", out int wisValue))
                {
                    wisBox.Text = wisValue.ToString();
                }
                if (GlobalVariables.sheetbuilderData[0].abilityScore.TryGetValue("Charisma", out int chaValue))
                {
                    chaBox.Text = chaValue.ToString();
                }


            }

            // If isEditMode, load character to edit:
            if (GlobalVariables.isEditMode && GlobalVariables.sheetbuilderData.Count <= 0)
            {
                CharacterSheet character = GlobalVariables.selectedCharacter;
                
                // Names
                cName_txt.Text = character.CharacterName;
                pName_txt.Text = character.PlayerName;

                // Size, HP, Class
                sizeCmb.Text = character.Race.Size.ToString();
                hp_txt.Text = character.HitPoints.ToString();
                class_txt.Text = character.Class;


                // Level
                foreach (ComboBoxItem item in LvlCmb.Items)
                {
                    if (item.Content.ToString() == character.Level.ToString())
                    {
                        LvlCmb.SelectedItem = item;
                        break;
                    }
                }

                // Race
                foreach (ComboBoxItem item in raceCmb.Items)
                {
                    if (item.Content.ToString() == character.Race.Name)
                    {
                        raceCmb.SelectedItem = item;
                        break;
                    }
                }

                // Type
                foreach (ComboBoxItem item in typeCmb.Items)
                {
                    if (item.Content.ToString() == character.Type)
                    {
                        typeCmb.SelectedItem = item;
                        break;
                    }
                }

                // Abilities
                strBox.Text = character.Abilities["Strength"].ToString();
                dexBox.Text = character.Abilities["Dexterity"].ToString();
                conBox.Text = character.Abilities["Constitution"].ToString();
                intBox.Text = character.Abilities["Intelligence"].ToString();
                wisBox.Text = character.Abilities["Wisdom"].ToString();
                chaBox.Text = character.Abilities["Charisma"].ToString();

                // Proficiencies, Equipment, Spells
                GlobalVariables.CurrentProficiencies = character.Proficiencies;
                GlobalVariables.CurrentEquipment = character.Equipment;
                GlobalVariables.CurrentSpells = character.Spells;

            } // End edit mode data population


            strBox.TextChanged += StrBox_TextChanged;
            dexBox.TextChanged += DexBox_TextChanged;
            conBox.TextChanged += ConBox_TextChanged;
            intBox.TextChanged += IntBox_TextChanged;
            wisBox.TextChanged += WisBox_TextChanged;
            chaBox.TextChanged += ChaBox_TextChanged;

        }

        private void StrBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            if (int.TryParse(strBox.Text, out int mod))
            {
                mod = (mod - 10) / 2;
                if (mod >= 0)
                {
                    strMod.Content = $"+{mod}";
                }
                else if (mod < 0)
                {
                    strMod.Content = $"-{mod}";
                }
                else
                {
                    strMod.Content = "+0";
                }
            }
            

        }

        private void DexBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int mod = 0;
            if (int.TryParse(dexBox.Text, out mod))
            {
                mod = (mod - 10) / 2;
                if (mod >= 0)
                {
                    dexMod.Content = $"+{mod}";
                }
                else if (mod < 0)
                {
                    dexMod.Content = $"-{mod}";
                }
                else
                {
                    dexMod.Content = "+0";
                }
            }


        }

        private void ConBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int mod = 0;
            if (int.TryParse(conBox.Text, out mod))
            {
                mod = (mod - 10) / 2;
                if (mod >= 0)
                {
                    conMod.Content = $"+{mod}";
                }
                else if (mod < 0)
                {
                    conMod.Content = $"-{mod}";
                }
                else
                {
                    conMod.Content = "+0";
                }
            }


        }

        private void IntBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int mod = 0;
            if (int.TryParse(intBox.Text, out mod))
            {
                mod = (mod - 10) / 2;
                if (mod >= 0)
                {
                    intMod.Content = $"+{mod}";
                }
                else if (mod < 0)
                {
                    intMod.Content = $"-{mod}";
                }
                else
                {
                    intMod.Content = "+0";
                }
            }


        }

        private void WisBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int mod = 0;
            if (int.TryParse(wisBox.Text, out mod))
            {
                mod = (mod - 10) / 2;
                if (mod >= 0)
                {
                    wisMod.Content = $"+{mod}";
                }
                else if (mod < 0)
                {
                    wisMod.Content = $"-{mod}";
                }
                else
                {
                    wisMod.Content = "+0";
                }
            }


        }

        private void ChaBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int mod = 0;
            if (int.TryParse(chaBox.Text, out mod))
            {
                mod = (mod - 10) / 2;
                if (mod >= 0)
                {
                    chaMod.Content = $"+{mod}";
                }
                else if (mod < 0)
                {
                    chaMod.Content = $"-{mod}";
                }
                else
                {
                    chaMod.Content = "+0";
                }
            }


        }




        //again not the best way to presist data but for now this works
        public async void profs_btn(object sender, RoutedEventArgs e)
        {
            persist_data();
        }

        public async void equipment_btn(object sender, RoutedEventArgs e)
        {
            persist_data();
        }

        public async void spells_btn(object sender, RoutedEventArgs e)
        {
            persist_data();
        }


        private async void saveBtn_Click(object sender, RoutedEventArgs e)
        {
                CharacterSheet newCharacter = new CharacterSheet();

                // Set Names
                newCharacter.CharacterName = cName_txt.Text;
                newCharacter.PlayerName = pName_txt.Text;

                // Set Size
                Enums.Sizes size;
                if (Enum.TryParse(sizeCmb.Text, out size))
                {
                    newCharacter.Race.Size = size;
                }
                else
                {
                    newCharacter.Race.Size = Enums.Sizes.Tiny; // Default
                }

                // Set Level
                int lvl = 0;
                if (int.TryParse(LvlCmb.Text, out lvl))
                {
                    newCharacter.Level = lvl;
                }

                // Set Type
                newCharacter.Type = typeCmb.Text;
                

                // Set HP
                int hp = 0;
                if (int.TryParse(hp_txt.Text, out hp))
                {
                    newCharacter.HitPoints = hp;
                }
                else
                {
                    newCharacter.HitPoints = 100; // Default
                }

                // Set Race Name
                newCharacter.Race.Name = raceCmb.Text;

                // Set Class
                newCharacter.Class = class_txt.Text;

                // Set equipment
                newCharacter.Equipment = GlobalVariables.CurrentEquipment;

            // Set proficiencies
            newCharacter.Proficiencies = GlobalVariables.CurrentProficiencies;

            // Set spells
            newCharacter.Spells = GlobalVariables.CurrentSpells;


            // Set Ability Scores
            try
            {
                Dictionary<string, int> abValue = new Dictionary<string, int>();
                abValue.Add("Strength",Int32.Parse(strBox.Text));
                abValue.Add("Dexterity",Int32.Parse(dexBox.Text));
                abValue.Add("Constitution",Int32.Parse(conBox.Text));
                abValue.Add("Intelligence",Int32.Parse(intBox.Text));
                abValue.Add("Wisdom",Int32.Parse(wisBox.Text));
                abValue.Add("Charisma",Int32.Parse(chaBox.Text));

                newCharacter.Abilities = abValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,ex.GetType().ToString(),MessageBoxButton.OK,MessageBoxImage.Error);
            }

            // Update in database
            if (GlobalVariables.isEditMode)
            {
                string connectionString = "mongodb+srv://aaronnewham03:0Fv6r1Ofg8YfqNEU@cluster0.qkbyhhq.mongodb.net/?retryWrites=true&w=majority";
                MongoHelper helper = new MongoHelper(connectionString, "NPCWizard");
                helper.UpdateCharacterById(GlobalVariables.selectedCharacter._id.ToString(), newCharacter);
                GlobalVariables.isEditMode = false;
            }
            // Save to database
            else
            {
                string connectionString = "mongodb+srv://aaronnewham03:0Fv6r1Ofg8YfqNEU@cluster0.qkbyhhq.mongodb.net/?retryWrites=true&w=majority";
                MongoHelper helper = new MongoHelper(connectionString, "NPCWizard");
                await helper.AddCharacterAsync(newCharacter);
            }
            


            

            //save charactersheet to allcharacter in the globaol vars
            GlobalVariables.AllCharacters.Add(newCharacter);
        }

        private void cancel_Btnclick(object sender, RoutedEventArgs e)
        {
            GlobalVariables.isEditMode = false;
        }


        private bool IsSheetBuilderActive()
        {
            // Check if the UserControl is currently the active one
            return this.IsVisible && this.IsEnabled;
        }


        //extermly not the best way
        //but simple way of persisting data in a window
        //since there will always be one item in the list this works
        public void persist_data()
        {
            //clear old data
            GlobalVariables.sheetbuilderData.Clear();

            sheetData currentData = new sheetData();

            currentData.characterName = cName_txt.Text;
            currentData.playerName = pName_txt.Text;


            // Set Size
            Enums.Sizes size;
            if (Enum.TryParse(sizeCmb.Text, out size))
            {
                currentData.size = size;
            }
            else
            {
                currentData.size = Enums.Sizes.Tiny; // Default
            }

            // Set Type
            currentData.type = typeCmb.Text;

            // Set AbScores
            Dictionary<string, int> abValue = new Dictionary<string, int>();
            abValue.Add("Strength", Int32.Parse(strBox.Text));
            abValue.Add("Dexterity", Int32.Parse(dexBox.Text));
            abValue.Add("Constitution", Int32.Parse(conBox.Text));
            abValue.Add("Intelligence", Int32.Parse(intBox.Text));
            abValue.Add("Wisdom", Int32.Parse(wisBox.Text));
            abValue.Add("Charisma", Int32.Parse(chaBox.Text));
            currentData.abilityScore = abValue;

            // Set HP
            int hp = 0;
            if (int.TryParse(hp_txt.Text, out hp))
            {
                currentData.hp = hp;
            }
            else
            {
                currentData.hp = 100; // Default
            }

            //set type
            currentData.type = typeCmb.Text;

            //set level
            // Set Level
            int lvl = 0;
            if (int.TryParse(LvlCmb.Text, out lvl))
            {
                currentData.level = lvl;
            }

            // Set Race Name
            currentData.raceName = raceCmb.Text;

            // Set Class
            currentData.characterClass = class_txt.Text;



            GlobalVariables.sheetbuilderData.Add(currentData);

        }
    }
}
