using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MurderMysteryCapstone.Models
{
    public class Journal
    {
        public enum JournalStatus
        {
            Incomplete,
            Complete
        }

        private int _id;
        private string _name;
        private string _description;
        private JournalStatus _status;
        private string _statusDetail;


        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public JournalStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public string StatusDetail
        {
            get { return _statusDetail; }
            set { _statusDetail = value; }
        }

        public Journal()
        {

        }

        public Journal(int id, string name, JournalStatus status)
        {
            _id = id;
            _name = name;
            _status = status;
        }

    }
}


   
