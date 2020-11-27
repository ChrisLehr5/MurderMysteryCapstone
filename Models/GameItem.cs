using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MurderMysteryCapstone.Models
{
    public class GameItem
    {
        public int Id { get; set; }
        public string Name { get; set; }        
        public string Description { get; set; }
        public string UseMessage { get; set; }
        public string Inspect { get; set; }

        public string Information
        {
            get
            {
                return InformationString();
            }
        }
        public GameItem(int id, string name, string description, string useMessage = "", string inspect = "")
        {
            Id = id;
            Name = name;           
            Description = description;
            UseMessage = useMessage;
            Inspect = inspect;
            
        }

        public virtual string InformationString()
        {
            return $"{Name}: {Description}";
        }
    }
}
