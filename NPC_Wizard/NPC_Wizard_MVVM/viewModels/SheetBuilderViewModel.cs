using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NPC_Wizard_MVVM.viewModels
{
    public class SheetBuilderViewModel : BaseViewModel
    {
      //  List<sheetData> sheetBuilderData { get; set; }
    }

    public class sheetData
    {
        public string characterName { get; set; }
        public string playerName { get; set; }

        public string type { get; set; }

        public int level { get; set; }

        public Enum size { get; set; }
        public int hp { get; set; }

        public string raceName { get; set; }
        public string characterClass { get; set; }

        public Dictionary<string,int> abilityScore { get; set; }

    }
}
