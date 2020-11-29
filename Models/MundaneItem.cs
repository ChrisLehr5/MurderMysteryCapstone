using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MurderMysteryCapstone.Models
{
    public class MundaneItem : GameItem
    {
        public enum UseActionType
        {
            OPENLOCATION,
            KILLPLAYER
        }

        public UseActionType UseAction { get; set; }

        public MundaneItem(int id, string name, string description, string useMessage, string inspect, UseActionType useAction)
             : base(id, name, description, useMessage, inspect)
        {          
            UseAction = useAction;
        }

        public override string InformationString()
        {
            return $"{Name}: {Description}";
        }
    }
}