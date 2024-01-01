using NPC_Wizard_MVVM.Object_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace main
{
    public interface IAbilityModifier
    {
        void AddModifier(Enums.Ability ability, int modifier);
    }
    public class AbilityScores : IAbilityModifier
    {
       /* public enum Ability
        {
            Strength,
            Dexterity,
            Constitution,
            Intelligence,
            Wisdom,
            Charisma
        };*/

        private Dictionary<Enums.Ability, int> abilityScores = new Dictionary<Enums.Ability, int>();

        private Dictionary<Enums.Ability, int> abilityModifiers = new Dictionary<Enums.Ability, int>();
        //Constructor with default values of 10 for each ability score

        public AbilityScores()
        {
            foreach (Enums.Ability ability in Enum.GetValues(typeof(Enums.Ability)))
            {
                abilityScores.Add(ability, 10);
            }

            foreach (Enums.Ability ability in Enum.GetValues((typeof(Enums.Ability))))
            {
                abilityModifiers.Add(ability, 0);
            }
        }
        public int Strength
        {
            get { return abilityScores[Enums.Ability.Strength]; }
            set { abilityScores[Enums.Ability.Strength] = value; }
        }
        public int Dexterity
        {
            get { return abilityScores[Enums.Ability.Dexterity]; }
            set { abilityScores[Enums.Ability.Dexterity] = value; }
        }
        public int Constitution
        {
            get { return abilityScores[Enums.Ability.Constitution]; }
            set { abilityScores[Enums.Ability.Constitution] = value; }
        }
        public int Intelligence
        {
            get { return abilityScores[Enums.Ability.Intelligence]; }
            set { abilityScores[Enums.Ability.Intelligence] = value; }
        }
        public int Wisdom
        {
            get { return abilityScores[Enums.Ability.Wisdom]; }
            set { abilityScores[Enums.Ability.Wisdom] = value; }
        }
        public int Charisma
        {
            get { return abilityScores[Enums.Ability.Charisma]; }
            set { abilityScores[Enums.Ability.Charisma] = value; }
        }
        //Ability score modifier getter
        public int GetModifier(Enums.Ability ability)
        {
            return (abilityScores[ability] - 10) / 2;
        }
        //Add modifier to ability score
        public void AddModifier(Enums.Ability ability, int modifier)
        {
            abilityModifiers[ability] += modifier;
        }
        public void AddModifier(Enums.Ability ability)
        {
            int score = (abilityScores[ability] - 10) / 2;
            abilityModifiers[ability] += score;
        }
        public Dictionary<Enums.Ability, int> GetScores()
        {
            return this.abilityScores;
        }
        public Dictionary<Enums.Ability, int> GetModifiers()
        {
            foreach (var score in abilityModifiers)
            {
                AddModifier(score.Key);
            }
            return this.abilityModifiers;
        }
    }
}