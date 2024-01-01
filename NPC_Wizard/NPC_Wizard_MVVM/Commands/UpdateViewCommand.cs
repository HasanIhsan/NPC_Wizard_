
using NPC_Wizard_MVVM.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NPC_Wizard_MVVM.Commands
{
    public class UpdateViewCommand : ICommand
    {
        private MainViewModel viewModel;

        // Constructor to initialize the command with the MainViewModel
        public UpdateViewCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        // Determine if the command can be executed (always returns true)
        public bool CanExecute(object parameter)
        {
            return true;
        }

        // Execute the command to update the displayed ViewModel based on the provided parameter
        public void Execute(object parameter)
        {
            if (parameter is Type viewType)
            {
                Console.WriteLine($"Executing UpdateViewCommand for {viewType.Name}");
                if (viewType == typeof(LoginViewModel))
                {
                    viewModel.SelectedViewModel = new LoginViewModel();
                }
                else if (viewType == typeof(MainMenuViewModel))
                {
                    viewModel.SelectedViewModel = new MainMenuViewModel();
                }
                else if (viewType == typeof(SheetBuilderViewModel))
                {
                    viewModel.SelectedViewModel = new SheetBuilderViewModel();
                }
                else if (viewType == typeof(ProficiencyUIViewModel))
                {
                    viewModel.SelectedViewModel = new ProficiencyUIViewModel();
                }
                else if (viewType == typeof(SpellsUIViewModel))
                {
                    viewModel.SelectedViewModel = new SpellsUIViewModel();
                }
                else if(viewType == typeof(ItemViewModel))
                {
                    viewModel.SelectedViewModel = new ItemViewModel();
                }
                else if (viewType == typeof(SheetViewModel))
                {
                    viewModel.SelectedViewModel = new SheetViewModel();
                }
            }
        }
    }
}
