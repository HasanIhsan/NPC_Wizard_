using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPC_Wizard_MVVM.Object_Classes
{
    public class Item
    {
        public string Name { get; set; }
        public Enums.ItemType Type { get; set; }
        public bool AttunementReq { get; set; }
        public string Notes { get; set; }

        public Item() {
            Name = "";
            Type = Enums.ItemType.Staff;
            AttunementReq = false;
            Notes = "";
        }
        Item(string name, Enums.ItemType type, bool attunementReq, string notes)
        {
            Name = name;
            Type = type;
            AttunementReq = attunementReq;
            Notes = notes;
        }
    }
}
