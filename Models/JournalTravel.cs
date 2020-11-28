﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MurderMysteryCapstone.Models
{
    class JournalTravel : Journal
    {
        private int _id;
        private string _name;
        private string _description;
        private JournalStatus _status;
        private string _statusDetail;       

        private List<Location> _requiredLocations;

        public List<Location> RequiredLocations
        {
            get { return _requiredLocations; }
            set { _requiredLocations = value; }
        }


        public JournalTravel()
        {

        }

        public JournalTravel(int id, string name, JournalStatus status, List<Location> requiredLocations)
            : base(id, name, status)
        {
            _id = id;
            _name = name;
            _status = status;
            _requiredLocations = requiredLocations;
        }

        public List<Location> LocationsNotCompleted(List<Location> locationsTraveled)
        {
            List<Location> locationsToComplete = new List<Location>();

            foreach (var requiredLocation in _requiredLocations)
            {
                if (!locationsTraveled.Any(l => l.Id == requiredLocation.Id))
                {
                    locationsToComplete.Add(requiredLocation);
                }
            }

            return locationsToComplete;
        }
    }
}
