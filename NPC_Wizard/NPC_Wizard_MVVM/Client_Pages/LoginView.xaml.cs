using NPC_Wizard_MVVM.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NPC_Wizard_MVVM.Client_Pages
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
            //DataContext = new MainViewModel();
            // Basic code to get the MongoHelper set up
            //string connectionString = "mongodb+srv://aaronnewham03:0Fv6r1Ofg8YfqNEU@cluster0.qkbyhhq.mongodb.net/?retryWrites=true&w=majority";
            //MongoHelper helper = new MongoHelper(connectionString, "NPCWizard");
        }
    }
}
