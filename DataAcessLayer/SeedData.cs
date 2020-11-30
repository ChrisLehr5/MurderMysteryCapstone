using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MurderMysteryCapstone.Models;

namespace MurderMysteryCapstone.DataAcessLayer
{
    class SeedData
    {
        public static List<Player> GetAllPlayer()
        {
            return new List<Player>
            {
                new Player
                {
                    Id =1,
                    Name = "Max",
                    Age = 23,
                },

                new Player
                {
                    Id =2,
                    Name = "Robert",
                    Age =16,
                },


                new Player
                {
                    Id =3,
                    Name = "Sally",
                    Age =55,
                },


                new Player
                {
                    Id =4,
                    Name = "Lucy",
                    Age =46,
                }
            };
        }
    }
}
