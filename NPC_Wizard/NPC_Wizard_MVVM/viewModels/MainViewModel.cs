using NPC_Wizard_MVVM.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NPC_Wizard_MVVM.viewModels
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _selectedViewModel;

        // Property to control which ViewModel is currently displayed in the user interface
        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        // Command to update the displayed ViewModel based on user interaction
        public ICommand UpdateViewCommand { get; set; }

        public MainViewModel()
        {
            // Set the default ViewModel to LoginViewModel when the MainViewModel is created
            SelectedViewModel = new LoginViewModel();

            // Initialize the command responsible for updating the displayed ViewModel
            UpdateViewCommand = new UpdateViewCommand(this);
        }

       
    }
}
