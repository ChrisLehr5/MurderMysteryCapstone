using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MurderMysteryCapstone.Models;
using MurderMysteryCapstone.DataAcessLayer;

namespace MurderMysteryCapstone.BusinessLayer
{
    class PlayerRepository : IPlayerRespository, IDisposable
    {
        private IDataService _dataService;
        List<Player> _player;

        public PlayerRepository()
        {
            DataConfig dataConfig = new DataConfig();
            _dataService = dataConfig.SetDataService();

            try
            {
                _player = _dataService.GetAll() as List<Player>;
            }
            catch (Exception e)
            {
                string message = e.Message;
                throw;
            }
        }

        /// <summary>
        /// returns correct data type
        /// </summary>
        private IDataService SetDataService()
        {
            switch (DataConfig.dataType)
            {
                case DataType.JSON:
                    return new DataServiceJason();
                default:
                    throw new Exception();
            }
        }

        /// <summary>
        /// retrieves all Pokemon
        /// </summary>
        public IEnumerable<Player> GetAll()
        {
            return _player;
        }

        /// <summary>
        /// gets pokemon by ID
        /// </summary>
        public Player GetById(int id)
        {
            return _player.FirstOrDefault(c => c.Id == id);
        }

        /// <summary>
        /// Adds a new pokemon
        /// </summary>
        public void Add(Player player)
        {
            try
            {
                _dataService.Add(player);
                //_pokemon.Add(pokemon);
                //_dataService.WriteAll(_pokemon);
            }
            catch (Exception e)
            {
                string message = e.Message;
                throw;
            }
        }

        /// <summary>
        /// deletes a pokemon by ID
        /// </summary>
        public void Delete(int id)
        {
            try
            {
                _dataService.Delete(id);
                //_pokemon.Remove(_pokemon.FirstOrDefault(p => p.ID == id));

                //_dataService.WriteAll(_pokemon);
            }
            catch (Exception e)
            {
                string message = e.Message;
                throw;
            }
        }

        /// <summary>
        /// updates a pokemon by id
        /// </summary>
        public void Update(Player player)
        {
            try
            {
                _dataService.Update(player);

                //_pokemon.Remove(_pokemon.FirstOrDefault(p => p.ID == pokemon.ID));
                //_pokemon.Add(pokemon);
                //_dataService.WriteAll(_pokemon);
            }
            catch (Exception e)
            {
                string message = e.Message;
                throw;
            }
        }

        public void Dispose()
        {
            _dataService = null;
            _player = null;
        }

    }
}