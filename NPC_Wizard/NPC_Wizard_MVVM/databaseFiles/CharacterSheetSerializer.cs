using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace NPC_Wizard_MVVM.databaseFiles
{
    public class CharacterSheetSerializer
    {
        public static void SaveCharacterSheetToJson(CharacterSheet characterSheet, string filePath)
        {
            try
            {
                string json = JsonSerializer.Serialize(characterSheet, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                File.WriteAllText(filePath, json);

                Console.WriteLine("CharacterSheet saved to JSON file successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving CharacterSheet to JSON: " + ex.Message);
            }
        }

        public static CharacterSheet LoadCharacterSheetFromJson(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);

                    CharacterSheet characterSheet = JsonSerializer.Deserialize<CharacterSheet>(json);

                    if (characterSheet != null)
                    {
                        Console.WriteLine("CharacterSheet loaded from JSON file successfully.");
                        return characterSheet;
                    }
                    else
                    {
                        Console.WriteLine("Error loading CharacterSheet from JSON: Deserialization failed.");
                        return null;
                    }
                }
                else
                {
                    Console.WriteLine("Error loading CharacterSheet from JSON: File not found.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading CharacterSheet from JSON: " + ex.Message);
                return null;
            }
        }
    }
}
