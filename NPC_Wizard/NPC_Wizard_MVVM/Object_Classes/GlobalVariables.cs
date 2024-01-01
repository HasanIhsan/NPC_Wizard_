using NPC_Wizard_MVVM.Client_Pages;
using NPC_Wizard_MVVM.databaseFiles;
using NPC_Wizard_MVVM.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPC_Wizard_MVVM.Object_Classes
{
    public static class GlobalVariables
    {
        public static List<String> CurrentProficiencies { get; set; }
        public static List<String> CurrentEquipment { get; set; }
        public static List<ListDataSpells> CurrentSpells { get; set; }
        public static List<CharacterSheet> AllCharacters { get; set; }

        public static CharacterSheet selectedCharacter { get; set; }

        public static Boolean isEditMode { get; set; }

        //sheet builder data
        public static List<sheetData>? sheetbuilderData { get; set; } = new List<sheetData>();
    }
}
