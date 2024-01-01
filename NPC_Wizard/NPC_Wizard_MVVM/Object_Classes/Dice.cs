using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NPC_Wizard_MVVM.Object_Classes
{
    public class Dice
    {
        public List<int> PreviousRolls;



        public Dice()
        {
            PreviousRolls = new List<int>();
        }

        //Example input: "2d6" or "1d10"
        public int RollDice(string expression)
        {
            string[] parts = expression.Split('d');
            int numDice = int.Parse(parts[0]);
            int diceSize = int.Parse(parts[1]);

            Random random = new Random();
            int total = 0;

            for (int i = 0; i < numDice; i++)
            {
                total += random.Next(1, diceSize + 1);
            }

            PreviousRolls.Add(total);

            return total;
        }

    }
}
