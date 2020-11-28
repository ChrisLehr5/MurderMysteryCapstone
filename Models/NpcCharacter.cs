using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MurderMysteryCapstone.Models
{
    public class NpcCharacter : Npc, ISpeak, IPerception
    {
        public List<string> Messages { get; set; }
        public List<string> Perceptions { get; set; }
        //public PerceiveModeName BattleMode { get; set; }

        protected override string InformationText()
        {
            return $"{Name} - {Description}";
        }

        public NpcCharacter()
        {

        }
        public NpcCharacter(
               int id,
               string name,
               string description,
               List<string> messages,
               List<string> perceptions)

        {
            Messages = messages;
            Perceptions = perceptions;

        }
        /// <summary>
        /// generate a message or use default
        /// </summary>
        /// <returns>message text</returns>
        public string Speak()
        {
            if (this.Messages != null)
            {
                return GetMessage();
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// randomly select a message from the list of messages
        /// </summary>
        /// <returns>message text</returns>
        private string GetMessage()
        {
            Random r = new Random();
            int messageIndex = r.Next(0, Messages.Count());
            return Messages[messageIndex];
        }

        public string Perceive()
        {
            if (this.Perceptions != null)
            {
                return GetPerception();
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// randomly select a message from the list of messages
        /// </summary>
        /// <returns>message text</returns>
        private string GetPerception()
        {
            Random r = new Random();
            int perceptionIndex = r.Next(0, Perceptions.Count());
            return Perceptions[perceptionIndex];
        }

    }
}
