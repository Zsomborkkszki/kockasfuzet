using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kockasfuzet.Models;
using MySql.Data.MySqlClient;

namespace kockasfuzet.Controllers
{
    internal class SzolgaltatoController
    {
        static public List<Szolgaltato> GetUserData()
        {
            //Establishing connection to MySQL database
            MySqlConnection connector = new MySqlConnection();
            Console.WriteLine("Csatlakozás a MySql adatbázishoz...");
            System.Threading.Thread.Sleep(2000);
            connector.ConnectionString = "server=localhost;user=root;password=;database=kockasfuzet";
            connector.Open();
            Console.WriteLine("Sikeres csatlakozás a MySQL adatbázishoz");
            System.Threading.Thread.Sleep(1000);
            //File reading
            MySqlCommand command = new MySqlCommand("SELECT * FROM szolgaltato;", connector);
            MySqlDataReader reader = command.ExecuteReader();
            List<Szolgaltato> users = new List<Szolgaltato>();
            while (reader.Read())
            {
                string RovidNev = reader.GetString("RovidNev");
                string Nev = reader.GetString("Nev");
                string Ugyfelszolg = reader.GetString("Ugyfelszolgalat");
                Szolgaltato user = new Szolgaltato(RovidNev, Nev, Ugyfelszolg);
                users.Add(user);
            }
            connector.Close();
            return users;
        }
    }
}
