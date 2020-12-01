using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MurderMysteryCapstone.Models;
using Newtonsoft.Json;

namespace MurderMysteryCapstone.DataAcessLayer
{
    public class DataServiceJason : IDataService
    {
        private string _dataFilePath;

        /// <summary>
        /// read from json file
        /// </summary>
        public IEnumerable<Player> ReadAll()
        {
            List<Player> player;

            try
            {
                using (StreamReader sr = new StreamReader(_dataFilePath))
                {
                    string jsonString = sr.ReadToEnd();

                    player = JsonConvert.DeserializeObject<List<Player>>(jsonString);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return player;
        }

        /// <summary>
        /// write to json file
        /// </summary>
        public void WriteAll(IEnumerable<Player> player)
        {
            string jsonString = JsonConvert.SerializeObject(player, Formatting.Indented);

            try
            {
                StreamWriter writer = new StreamWriter(_dataFilePath);
                using (writer)
                {
                    writer.WriteLine(jsonString);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Player> GetAll()
        {
            throw new NotImplementedException();
        }

        public Player GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(Player player)
        {
            throw new NotImplementedException();
        }

        public void Update(Player player)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public DataServiceJason()
        {
            _dataFilePath = DataConfig.DataPathJson;
        }
    }
}
