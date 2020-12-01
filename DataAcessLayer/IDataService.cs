using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MurderMysteryCapstone.Models;

namespace MurderMysteryCapstone.DataAcessLayer
{
    public interface IDataService
    {
        IEnumerable<Player> ReadAll();

        IEnumerable<Player> GetAll();

        void WriteAll(IEnumerable<Player> player);

        Player GetByID(int id);

        void Add(Player player);
        void Update(Player player);

        void Delete(int id);

    }
}
