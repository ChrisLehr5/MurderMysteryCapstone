using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MurderMysteryCapstone.UtilityClass;
using MurderMysteryCapstone.Models;

namespace MurderMysteryCapstone.Views
{
    public class JournalStatusViewModel : ObservableObject
    {
        private string _journalInformation;
        private List<Journal> _journals;

        public List<Journal> Journals
        {
            get { return _journals; }
            set { _journals = value; }
        }

        public string JournalInformation
        {
            get { return _journalInformation; }
            set
            {
                _journalInformation = value;
                OnPropertyChanged(nameof(JournalInformation));
            }
        }
    }
}
    

