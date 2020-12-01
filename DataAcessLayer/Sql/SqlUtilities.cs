using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using MurderMysteryCapstone.Models;

namespace MurderMysteryCapstone.DataAcessLayer.Sql
{
    class SqlUtilities
    {
        public static bool WriteSeedDataToDatabase()
        {
            bool operationSuccessful = true;

            try
            {
                DeleteAllPlayerRecords();
                AddAllPlayerRecords();
            }
            catch (Exception msg)
            {
                operationSuccessful = false;
                var message = msg.Message;
                throw;
            }

            return operationSuccessful;
        }

        /// <summary>
        /// deletes all records
        /// </summary>
        private static bool DeleteAllPlayerRecords()
        {
            string connectionString = SqlDataSettings.ConnectionString;
            string sqlCommandString = "DELETE FROM PlayerInfo";
            bool operationSuccessful = true;

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
                    operationSuccessful = false;
                    throw;
                }
            }

            return operationSuccessful;
        }

        /// <summary>
        /// adds pokemon records from seed data
        /// </summary>
        private static bool AddAllPlayerRecords()
        {
            string connectionString = SqlDataSettings.ConnectionString;
            bool operationSuccessful = true;


            foreach (var player in SeedData.GetAllPlayer())
            {

                var sb = new StringBuilder("INSERT INTO PlayerInfo");
                sb.Append(" ([Id], [Name], [Age])");
                sb.Append(" Values (");
                sb.Append("'").Append(player.Id).Append("',");
                sb.Append("'").Append(player.Name).Append("',");
                sb.Append("'").Append(player.Age).Append("',");

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
                        operationSuccessful = false;
                        throw;
                    }
                }

            }
            return operationSuccessful;
        }
        
    }
}


