using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPC_Wizard_MVVM.Object_Classes
{
    public class Enums
    {
        public enum Ability
        {
            Strength,
            Dexterity,
            Constitution,
            Intelligence,
            Wisdom,
            Charisma
        };

        public enum Sizes
        { 
            Tiny,
            Small,
            Medium,
            Large,
            Huge,
            Gargantuan
        };

        public enum Schools
        {
            Conjuration,
            Necromancy,
            Evocation,
            Abjuration,
            Transmutation,
            Divination,
            Enchantment,
            Illusion
        };

        public enum SpellLevels
        {
            Cantrip,
            First,
            Second,
            Third,
            Fourth,
            Fifth,
            Sixth,
            Seventh,
            Eighth,
            Ninth
        }
        public enum SpellComponents
        {
            Verbal,
            Somatic,
            Material
        }
        public enum ItemType
        {
            Armor,
            Potion,
            Ring,
            Rod,
            Scroll,
            Staff,
            Wand,
            Weapon,
            Wondrous
        }
    }
}
