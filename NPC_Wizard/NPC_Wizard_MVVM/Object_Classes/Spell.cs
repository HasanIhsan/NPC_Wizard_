using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPC_Wizard_MVVM.Object_Classes
{
    public class Spell
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Enums.SpellLevels Level { get; set; }
        public Enums.Schools School { get; set; }
        public string CastingTime { get; set; }
        public string Range { get; set; }
        public List<Enums.SpellComponents> Components { get; set; }
        public string Duration { get; set; }

        //Default Spell constructor
        public Spell()
        {
            Name = "";
            Description = "";
            Level = Enums.SpellLevels.Cantrip;
            School = Enums.Schools.Enchantment;
            CastingTime = "";
            Range = "";
            Components = new List<Enums.SpellComponents>();
            Duration = "";
        }

        //Spell constructor with all properties 
        public Spell(string name, 
            string description,
            Enums.SpellLevels level, 
            Enums.Schools school, 
            string castingTime, 
            string range, 
            List<Enums.SpellComponents> components, 
            string duration)
        {
            Name = name;
            Description = description;
            Level = level;
            School = school;
            CastingTime = castingTime;
            Range = range;
            Components = components;
            Duration = duration;
        }
    }
}
