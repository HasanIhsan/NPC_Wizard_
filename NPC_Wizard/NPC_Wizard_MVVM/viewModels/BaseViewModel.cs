using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPC_Wizard_MVVM.viewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        // Event to notify that a property has changed and the UI should be updated
        public event PropertyChangedEventHandler PropertyChanged;

        // Helper method to raise the PropertyChanged event for a specific property
        protected void OnPropertyChanged(string propertyName)
        {
            // Invoke the PropertyChanged event, indicating that a property has changed
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
