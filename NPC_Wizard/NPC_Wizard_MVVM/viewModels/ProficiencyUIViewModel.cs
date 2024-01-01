using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NPC_Wizard_MVVM.viewModels
{
    public class ProficiencyUIViewModel : BaseViewModel
    {
        public ObservableCollection<string> SelectedDataSTRING { get; set; }
    }
}
