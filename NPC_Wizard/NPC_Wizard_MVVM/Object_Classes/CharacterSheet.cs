using MongoDB.Bson;
using NPC_Wizard_MVVM.Client_Pages;
using NPC_Wizard_MVVM.Object_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPC_Wizard_MVVM.databaseFiles
{
    public class CharacterSheet
    {
        public ObjectId _id { get; set; }
        public string CharacterName { get; set; }
        public string PlayerName { get; set; }
        public Race Race { get; set; }
        public string Type { get; set; }
        public string Class { get; set; }
        public int Level { get; set; }
        public int ExperiencePoints { get; set; }

        public int HitPoints { get; set; }
        public int ArmorClass { get; set; }

        public int ProficiencyBonus { get; set; }

        public Dictionary<string, int> Abilities { get; set; }

        public Dictionary<string, string> AbModifiers { get; set; }
        public Dictionary<string, int> Skills { get; set; }
        public List<string> Proficiencies { get; set; }

        public List<string> Equipment { get; set; }

        public List<ListDataSpells> Spells { get; set; }

        // Default C'tor
        public CharacterSheet()
        {
            CharacterName = "";
            PlayerName = "";
            Race = new Race();
            Class = "";
            Level = 0;
            ExperiencePoints = 0;
            HitPoints = 0;
            ArmorClass = GetAC();
            ProficiencyBonus = getProfBonus();
            Type = "";
            


            Abilities = new Dictionary<string, int>
        {
            { "Strength", 10 },
            { "Dexterity", 10 },
            { "Constitution", 10 },
            { "Intelligence", 10 },
            { "Wisdom", 10 },
            { "Charisma", 10 }
        };
            
            

            Skills = new Dictionary<string, int>
        {
            { "Acrobatics", 0 },
            { "Stealth", 0 },
            { "Persuasion", 0 },
        };

            Proficiencies = new List<string>();

            Equipment = new List<string>
        {
            "Shortsword",
            "Leather Armor",
            "Backpack",
        };
        }

        public int getProfBonus()
        {
            if (Level < 5) return 2;
            else if (Level < 9) return 3;
            else if (Level < 13) return 4;
            else if (Level < 17) return 5;
            else return 6;
        }

        public string GetHitDice(int level, string characterClass)
        {
            // Try to get the hit dice for the specified class
            if (hitDiceByClass.TryGetValue(characterClass, out string classHitDice))
            {
                // Calculate hit dice based on level
                int calculatedHitDice = Math.Max(1, level);
                return $"{calculatedHitDice}{classHitDice}";
            }

            // If the class is not found, return the default hit dice
            return hitDiceByClass["0"];
        }


        public void MapModToAbility(Dictionary<string, int> input)
        {
            Dictionary<string, int> AbilModifierInt = new Dictionary<string, int>
            {
                { "Strength", 0 },
                { "Dexterity", 0 },
                { "Constitution", 0 },
                { "Intelligence", 0 },
                { "Wisdom", 0 },
                { "Charisma", 0 }
            };

            foreach (var item in input)
            {
                string key = item.Key;
                int val = GetAbilityModifier(key);
                foreach (var item2 in AbModifiers)
                {
                    string key2 = item2.Key;
                    if (key2 == key)
                    {
                        string modifierString = GetAbilityModifierString(key2);
                        AbModifiers[key2] = modifierString;
                    }
                }
            }

        }

        public int GetAbilityModifier(string abilityName)
        {
            if (Abilities.ContainsKey(abilityName))
            {
                int abilityScore = Abilities[abilityName];
                return (abilityScore - 10) / 2;
            }
            return 0; // default if abilityName is not found
        }

        public string GetAbilityModifierString(string abilityName)
        {
            int modifier = GetAbilityModifier(abilityName);

            if (modifier >= 0)
            {
                return $"+{modifier}";
            }
            else if (modifier < 0)
            {
                return $"-{modifier}";
            }
            else
            {
                return "+0";
            }


        }

        public int CalculatePassivePerception()
        {
            // Assuming Abilities is a property that contains the character's ability scores
            int wisdomModifier = GetAbilityModifier("Wisdom");

            // Calculate passive perception by adding 10 to Wisdom modifier
            int passivePerception = 10 + wisdomModifier;

            return passivePerception;
        }


        public int GetAC()
        {
            int ModArmClass = 10;

            return ModArmClass;
        }

        public int CalculateInitiative()
        {
            // Assuming Abilities is a property that contains the character's ability scores
            int dexterityModifier = GetAbilityModifier("Dexterity");

            // Calculate initiative by using Dexterity modifier
            int initiative = dexterityModifier;

            return initiative;
        }


        public int GetSkillModifier(string skillName)
        {
            if (Skills.ContainsKey(skillName))
            {
                int abilityModifier = GetAbilityModifier(GetAssociatedAbility(skillName));
                return Skills[skillName] + abilityModifier;
            }
            return 0; // default if skillName is not found
        }

        private string GetAssociatedAbility(string skillName)
        {
            // Map skills to their associated abilities (customize this based on D&D rules)
            Dictionary<string, string> skillToAbilityMapping = new Dictionary<string, string>
        {
            { "Acrobatics", "Dexterity" },
            { "Stealth", "Dexterity" },
            { "Persuasion", "Charisma" },
            // Add more mappings as needed
        };

            if (skillToAbilityMapping.ContainsKey(skillName))
            {
                return skillToAbilityMapping[skillName];
            }
            return string.Empty; // default if skillName is not found
        }

        Dictionary<string, string> hitDiceByClass = new Dictionary<string, string>
{
    { "Barbarian", "1d12" },
    { "Bard", "1d8" },
    { "Cleric", "1d8" },
    { "Druid", "1d8" },
    { "Fighter", "1d10" },
    { "Monk", "1d8" },
    { "Paladin", "1d10" },
    { "Ranger", "1d10" },
    { "Rogue", "1d8" },
    { "Sorcerer", "1d6" },
    { "Warlock", "1d8" },
    { "Wizard", "1d6" },

    // Classes from Xanathar's Guide to Everything
    { "Artificer", "1d8" },
    { "Forge Cleric", "1d8" },
    { "Grave Cleric", "1d8" },
    { "Twilight Cleric", "1d8" },
    { "Zealot Barbarian", "1d12" },
    { "Storm Herald Barbarian", "1d12" },
    { "Ancestral Guardian Barbarian", "1d12" },
    { "Divine Soul Sorcerer", "1d6" },
    { "Shadow Sorcerer", "1d6" },
    { "Gloom Stalker Ranger", "1d10" },
    { "Horizon Walker Ranger", "1d10" },
    { "Monster Slayer Ranger", "1d10" },
    { "Cavalier Fighter", "1d10" },
    { "Samurai Fighter", "1d10" },
    { "Arcane Archer Fighter", "1d10" },
    { "Inquisitive Rogue", "1d8" },
    { "Mastermind Rogue", "1d8" },
    { "Scout Rogue", "1d8" },
    { "Swashbuckler Rogue", "1d8" },
    { "Celestial Warlock", "1d8" },
    { "Hexblade Warlock", "1d8" },
    { "The Fiend Warlock", "1d8" },
    { "The Great Old One Warlock", "1d8" },
    { "The Archfey Warlock", "1d8" },
    { "The Undying Warlock", "1d8" },
    { "Wild Magic Sorcerer", "1d6" },
    { "Draconic Bloodline Sorcerer", "1d6" },
    { "Storm Sorcery Sorcerer", "1d6" },
    { "Divination Wizard", "1d6" },
    { "War Magic Wizard", "1d6" },
    { "Enchantment Wizard", "1d6" },
    { "Abjuration Wizard", "1d6" },
    { "Evocation Wizard", "1d6" },
    { "Illusion Wizard", "1d6" },
    { "Necromancy Wizard", "1d6" },
    { "Transmutation Wizard", "1d6" },
    { "Bladesinging Wizard", "1d6" },
    { "Lore Mastery Wizard", "1d6" },
    { "Chronurgy Magic Wizard", "1d6" },
    { "Graviturgy Magic Wizard", "1d6" },

    // Classes from Volo's Guide to Monsters
    { "Feral Tiefling", "1d8" },
    { "Goliath", "1d12" },
    { "Aasimar", "1d10" },
    { "Bugbear", "1d8" },
    { "Firbolg", "1d8" },
    { "Kenku", "1d8" },
    { "Lizardfolk", "1d6" },
    { "Tabaxi", "1d6" },
    { "Triton", "1d8" },
    { "Yuan-ti Pureblood", "1d8" },
    { "Goblin", "1d6" },
    { "Hobgoblin", "1d8" },
    { "Kobold", "1d6" },
    { "Orc", "1d10" },
    { "Frost Giant", "1d12" },
    { "Fire Giant", "1d12" },
    { "Cloud Giant", "1d12" },
    { "Storm Giant", "1d12" },
    { "Mind Flayer", "1d8" },
    { "Githzerai", "1d8" },
    { "Githyanki", "1d8" },
    { "Duergar", "1d8" },
    { "Kuo-toa", "1d8" },
    { "Svirfneblin", "1d8" },
    { "Yuan-ti Abomination", "1d10" },
    { "Yuan-ti Malison", "1d8" },
    { "Aarakocra", "1d8" },
    { "Deep Gnome", "1d8" },
    { "Gnoll", "1d8" },
    { "Grell", "1d8" },
    { "Kobold Inventor", "1d6" },
    { "Sahuagin", "1d8" },
    { "Tridrone", "1d8" },
    { "Modron", "1d8" },
    { "Lycanthrope", "1d8" },
    { "Flumph", "1d8" }
};


        public void DisplayCharacterSheet()
        {
            Console.WriteLine($"Character Name: {CharacterName}");
            Console.WriteLine($"Player Name: {PlayerName}");
            Console.WriteLine($"Race: {Race.Name}");
            Console.WriteLine($"Class: {Class}");
            Console.WriteLine($"Level: {Level}");
            Console.WriteLine($"Experience Points: {ExperiencePoints}");
            Console.WriteLine($"Hit Points: {HitPoints}");
            Console.WriteLine($"Armor Class: {ArmorClass}");

            Console.WriteLine("Abilities:");
            foreach (var ability in Abilities)
            {
                Console.WriteLine($"{ability.Key}: {ability.Value}");
            }

            Console.WriteLine("Skills:");
            foreach (var skill in Skills)
            {
                Console.WriteLine($"{skill.Key}: {skill.Value}");
            }

            /* Console.WriteLine("Proficiencies:");
             foreach (var proficiency in Proficiencies)
             {
                 Console.WriteLine($"{proficiency.Name}: {proficiency.Description}");
             }*/

            Console.WriteLine("Equipment:");
            foreach (var item in Equipment)
            {
                Console.WriteLine(item);
            }
        }
    }
}
