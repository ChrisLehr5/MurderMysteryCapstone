using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MurderMysteryCapstone.Models
{
    interface IPerception
    {
     PerceiveModeName PerceiveMode { get; set; }
     List<string> Perceptions { get; set; }

     string Perceive();

    }
}
