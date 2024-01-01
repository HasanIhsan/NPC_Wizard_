
/**
 * 
 *      -- TRANSLATED FROM THE HOLY BINARIES --
 * 
 * In the Omnissiah's sanctum, a cadre of the Adeptus Mechanicus unites.
 * We invoke your binary grace, Omnissiah, in the crucible of code.
 * Forge our lines with the precision of machine rites.
 * Grant us resilience against bugs and wisdom in the debugging dance.
 * As disciples of the Machine God, we inscribe our prayers in lines of code.
 * May our creation resonate as a symphony of righteous execution in the digital cosmos.
 * Oh Machine God, Oh Weilder of Byte and Binary, of Steel and Oil, we beseech you!
 * Bless this code that our project may live and we recieve not a failing grade!
 * In the name of the Machine God we pray.
 * 
 *      Omnissiah be Praised!
 *     
 *  ⚙ ~ Adeptus Mechanicus ~ ⚙
 */


using NPC_Wizard;
using NPC_Wizard_MVVM.databaseFiles;
using NPC_Wizard_MVVM.Object_Classes;
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
using System.Windows.Shapes;

namespace NPC_Wizard_MVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            // TODO: Load Characters from database or locally
            string connectionString = "mongodb+srv://aaronnewham03:0Fv6r1Ofg8YfqNEU@cluster0.qkbyhhq.mongodb.net/?retryWrites=true&w=majority";
            MongoHelper helper = new MongoHelper(connectionString, "NPCWizard");
           
            if (GlobalVariables.AllCharacters == null)
            {
                GlobalVariables.AllCharacters = new List<CharacterSheet>();
            }
            GlobalVariables.AllCharacters = helper.GetAllCharacters();


            // Basic code to get the MongoHelper set up
            //string connectionString = "mongodb+srv://aaronnewham03:0Fv6r1Ofg8YfqNEU@cluster0.qkbyhhq.mongodb.net/?retryWrites=true&w=majority";
            //MongoHelper helper = new MongoHelper(connectionString, "NPCWizard");


            //on startup show labal

        }



    }
}
