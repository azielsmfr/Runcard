using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Dapper;

namespace RunCard.Classes
{
    public class DataAccess
    {
        public static List<AddressModel> GetAllLocations()
        {


            // List<AddressModel> stations = new List<AddressModel>();
            string conn = LoadConnectionString();

            using (IDbConnection cnn = new SQLiteConnection(conn))
            {
                try
                {
                    string query = "select * from Locations";

                    //if (!String.IsNullOrEmpty(address) ) { 
                    
                    //    query += " where Location like " + "'%" + address + "%'";
                    //}

                    query += " order by Location";


                    var output = cnn.Query<AddressModel>(query, new DynamicParameters());
                    return output.ToList();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            try
            {
                // string connectionString = ConfigurationManager.ConnectionStrings[id].ConnectionString;

               

                //string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                string connectionString = "Data Source="+ path + "\\RuncardDB\\Locations.db; Version=3";

                return connectionString;
            }
            catch (Exception ex) {

                throw ex;
            }

        }

    }
}
