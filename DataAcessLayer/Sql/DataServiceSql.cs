using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using MurderMysteryCapstone.Models;

namespace MurderMysteryCapstone.DataAcessLayer.Sql
{
    class DataServiceSql : IDataService
    {
        #region Fields

        private List<Player> _player;

        #endregion

        #region Constructors

        public DataServiceSql()
        {
            DataSet player_ds = GetDataSet();
            _player = GetPlayer(player_ds);
        }

        #endregion

        #region Methods

        /// <summary>
        /// queries the data set and generates a list of pokemon
        /// </summary>
        private List<Player> GetPlayer(DataSet player_ds)
        {
            DataTable player_dt = player_ds.Tables["Player"];

            List<Player> player = (from p in player_dt.AsEnumerable()
                                     select new Player()
                                     {
                                         Id = Convert.ToInt32(p["Id"]),
                                         Name = Convert.ToString(p["Name"]),
                                         Age = Convert.ToInt32(p["Age"])                                         
                                     }).ToList();

            return player;
        }        

        /// <summary>
        /// connect to sql and return all the tables
        /// </summary>
        /// <returns></returns>
        private DataSet GetDataSet()
        {
            DataSet player_DataSet = new DataSet();

            string connectionString = SqlDataSettings.ConnectionString;
            string sqlCommandString = "SELECT * from Player";

            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(sqlCommandString, sqlConn);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlConn.Open();

                    sqlDataAdapter.Fill(player_DataSet, "Player");
                }
                catch (SqlException sqlException)
                {
                    var exceptionMessage = sqlException.Message;
                    throw;
                }
            }

            return player_DataSet;
        }

        /// <summary>
        /// gets all of the pokemon
        /// </summary>
        public IEnumerable<Player> GetAll()
        {
            return _player;
        }

        /// <summary>
        /// retirieves pokemon by ID
        /// </summary>
        public Player GetByID(int id)
        {
            return _player.FirstOrDefault(p => p.Id == id);
        }

        /// <summary>
        /// add a Pokemon
        /// </summary>
        public void Add(Player player)
        {
            Delete(player.Id);

            string connectionString = SqlDataSettings.ConnectionString;           

            var sb = new StringBuilder("INSERT INTO Player");
            sb.Append(" ([Id], [Name], [Type], [Weakness], [Abilities], [Weight], [Height], [Description], [Category], [ImageFileName])");
            sb.Append(" Values (");
            sb.Append("'").Append(player.Id).Append("',");
            sb.Append("'").Append(player.Name).Append("',");         
            sb.Append("'").Append(player.Age).Append("')");

            string sqlCommandString = sb.ToString();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter sqlAdapter = new SqlDataAdapter();
                    sqlConnection.Open();
                    sqlAdapter.InsertCommand = new SqlCommand(sqlCommandString, sqlConnection);
                    sqlAdapter.InsertCommand.ExecuteNonQuery();
                }
                catch (Exception msg)
                {
                    var exceptionMessage = msg.Message;
                    throw;
                }
            }
        }

        /// <summary>
        /// updates a pokemon
        /// </summary>
        public void Update(Player player)
        {
            string connectionString = SqlDataSettings.ConnectionString;
        

            var sb = new StringBuilder("UPDATE Player SET ");
            sb.Append("Id = '").Append(player.Id).Append("' ");
            sb.Append("Name = '").Append(player.Name).Append("' ");
            sb.Append("Age = '").Append(player.Age).Append("' ");
            sb.Append("WHERE Id = ").Append(player.Id);

            string sqlCommandString = sb.ToString();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter sqlAdapter = new SqlDataAdapter();
                    sqlConnection.Open();
                    sqlAdapter.DeleteCommand = new SqlCommand(sqlCommandString, sqlConnection);
                    sqlAdapter.DeleteCommand.ExecuteNonQuery();
                }
                catch (Exception msg)
                {
                    var exceptionMessage = msg.Message;
                    throw;
                }
            }
        }


        /// <summary>
        /// delete a pokemon
        /// </summary>
        public void Delete(int id)
        {
            string connectionString = SqlDataSettings.ConnectionString;

            var sb = new StringBuilder("DELETE FROM Player");
            sb.Append(" WHERE Id = ").Append(id);
            string sqlCommandString = sb.ToString();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter sqlAdapter = new SqlDataAdapter();
                    sqlConnection.Open();
                    sqlAdapter.DeleteCommand = new SqlCommand(sqlCommandString, sqlConnection);
                    sqlAdapter.DeleteCommand.ExecuteNonQuery();
                }
                catch (Exception msg)
                {
                    var exceptionMessage = msg.Message;
                    throw;
                }
            }
        }

        
        

        public IEnumerable<Player> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void WriteAll(IEnumerable<Player> pokemon)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
