/*
    Author(s): Aaron Newham
    Last Modified: 2023-10-24
 */
using main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPC_Wizard_MVVM.Object_Classes
{
    /*------ RACE CLASS ------*/
    public class Race
    {
        // Properties
        public AbilityScores AbilityScores { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Alignment { get; set; }
        public Enums.Sizes Size { get; set; }
        public int Speed { get; set; }
        public string Description { get; set; }
        public List<string> Languages { get; set; }
        public List<SubRace> SubRaces { get; set; }
        public List<Trait> Traits { get; set; }

        // Default C'tor
        public Race()
        {
            // Initialize the properties with default values
            AbilityScores = new AbilityScores();
            Name = "";
            Age = 0;
            Alignment = "";
            Size = Enums.Sizes.Medium;
            Speed = 0;
            Description = "";
            Languages = new List<string>();
            SubRaces = new List<SubRace>();
            Traits = new List<Trait>();
        }

        // C'tor with all properties
        public Race(
        AbilityScores abilityScores,
        string name,
        int age,
        string alignment,
        Enums.Sizes size,
        int speed,
        string description,
        List<string> languages,
        List<SubRace> subRaces,
        List<Trait> traits)
        {
            AbilityScores = abilityScores;
            Name = name;
            Age = age;
            Alignment = alignment;
            Size = size;
            Speed = speed;
            Description = description;
            Languages = languages;
            SubRaces = subRaces;
            Traits = traits;
        }

        // C'tor with empty lists by default
        public Race(
        AbilityScores abilityScores,
        string name,
        int age,
        string alignment,
        Enums.Sizes size,
        int speed,
        string description)
        {
            AbilityScores = abilityScores;
            Name = name;
            Age = age;
            Alignment = alignment;
            Size = size;
            Speed = speed;
            Description = description;

            // Initialize List<> properties as empty lists
            Languages = new List<string>();
            SubRaces = new List<SubRace>();
            Traits = new List<Trait>();
        }

        // Add language
        public void AddLanguage(string language)
        { 
            this.Languages.Add(language);
        }

        // Remove language
        public void RemoveLanguage(string language)
        { 
            this.Languages.Remove(language);
        }

        // Add SubRace
        public void AddSubRace(SubRace subRace)
        { 
            this.SubRaces.Add(subRace);
        }

        // Remove SubRace
        public void RemoveSubRace(SubRace subRace)
        { 
            this.SubRaces.Remove(subRace);
        }

        // Remove SubRace by name
        public void RemoveSubRaceByName(string name) 
        {
            for (int i = 0; i < this.SubRaces.Count; i++)
            {
                if (this.SubRaces[i].Name.Equals(name))
                {
                    this.SubRaces.RemoveAt(i);
                }
            }
        }

        // Add Trait
        public void AddTrait(Trait trait) 
        { 
            this.Traits.Add(trait);
        }

        // Remove Trait
        public void RemoveTrait(Trait trait)
        {
            this.Traits.Remove(trait);
        }

        // Remove Trait by name
        public void RemoveTraitByName(string name)
        {
            for (int i = 0; i < this.Traits.Count; i++)
            {
                if (this.Traits[i].Name.Equals(name))
                { 
                    this.Traits.RemoveAt(i);
                }
            }
        }
    } // End race class

    /*------ SUBRACE CLASS ------*/
    public class SubRace
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Alignment { get; set; }
        public List<Trait> Traits { get; set; }

        // Default C'tor
        public SubRace()
        {
            Name = "";
            Description = "";
            Alignment = "";
            Traits = new List<Trait>();
        }

        // C'tor
        public SubRace(string name, string description, string alignment, List<Trait> traits)
        {
            Name = name;
            Description = description;
            Alignment = alignment;
            Traits = traits;
        }

        // Add Trait
        public void AddTrait(Trait trait)
        {
            this.Traits.Add(trait);
        }

        // Remove Trait
        public void RemoveTrait(Trait trait)
        {
            this.Traits.Remove(trait);
        }

        // Remove Trait by name
        public void RemoveTraitByName(string name)
        {
            for (int i = 0; i < this.Traits.Count; i++)
            {
                if (this.Traits[i].Name.Equals(name))
                {
                    this.Traits.RemoveAt(i);
                }
            }
        }

    } // End SubRace class

    /*------ TRAIT CLASS ------*/
    public class Trait
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Trait(string name, string description)
        {
            Name = name;
            Description = description;
        }
    } // End Trait class
}
