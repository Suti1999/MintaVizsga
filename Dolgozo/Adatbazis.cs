using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Dolgozo
{
    internal class Adatbazis
    {
        MySqlConnection connection;
        MySqlCommand command;

        public Adatbazis()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();

            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "dolgozok";
            
            connection=new MySqlConnection(builder.ConnectionString);
            command = connection.CreateCommand();

            try
            {
                kapcsolatNyit();
                kapcsolatZar();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }
        }

        private void kapcsolatZar()
        {
            if(connection.State != System.Data.ConnectionState.Closed)
            {
                connection.Close();
            }
        }

        private void kapcsolatNyit()
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
        }

        internal List<Dolgozo> GetAllDolgozo()
        {
            List<Dolgozo> dolgozos = new List<Dolgozo>();
            command.CommandText = "SELECT `dolgozoid`, `nev`,`neme`, `reszleg`, `belepesev`, `ber` FROM `dolgozok`";
            kapcsolatNyit();

            using (MySqlDataReader dr = command.ExecuteReader())
            {
                while (dr.Read())
                {
               
                    Dolgozo uj = new Dolgozo(dr.GetInt32("dolgozoid"), dr.GetString("nev"), dr.GetString("neme"), dr.GetString("reszleg"), dr.GetInt32("belepesev"), dr.GetInt32("ber"));
                    dolgozos.Add(uj);
                }
            }
                return dolgozos;
        }
    }
}
