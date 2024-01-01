using NPC_Wizard_MVVM.Client_Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPC_Wizard_MVVM.viewModels
{
    public class SpellsUIViewModel : BaseViewModel
    {
        public ObservableCollection<ListDataSpells> SelectedDataSTRING { get; set; }
    }
}
