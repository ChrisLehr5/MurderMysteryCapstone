using MurderMysteryCapstone.DataAcessLayer.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MurderMysteryCapstone.DataAcessLayer
{
    class DataConfig
    {      

        public static DataType dataType = DataType.SQL;

        public static string DataPathJson => @"DataAccessLayer\Json\pokemonList.json";
        public static string DataPathXml => @"DataAccessLayer\Xml\pokemonList.xml";

        public IDataService SetDataService()
        {
            switch (dataType)
            {
                case DataType.XML:
                    //return new DataServiceXml();
                case DataType.JSON:
                   // return new DataServiceJason();
                case DataType.SQL:
                    return new DataServiceSql();
                default:
                    throw new Exception();
            }
        }
    }
}
