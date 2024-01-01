using NPC_Wizard_MVVM.databaseFiles;
using NPC_Wizard_MVVM.Object_Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for Sheet_Display.xaml
    /// </summary>
    public partial class Sheet_Display : UserControl
    {

        public Sheet_Display()
        {
            InitializeComponent();
            //CharacterSheet charSheet = new CharacterSheet();

            Debug.WriteLine(GlobalVariables.AllCharacters.Count());
            DataContext = GlobalVariables.AllCharacters.Last();


        }


       
        
        
    }
}
