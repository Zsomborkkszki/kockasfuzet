using Kockasfuzet.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kockasfuzet.Controllers
{
    internal class SzamlaController
    {
        public List<Szamla> GetSzamlaList()
        {
            MySqlConnection connection = new MySqlConnection();
            string connectionString = "SERVER=localhost;DATABASE=kockasfuzet;UID=root;PASSWORD=;";
            connection.ConnectionString = connectionString;
            try
            {
                connection.Open();
                string sql = "SELECT * FROM szamla";
                MySqlCommand command = new MySqlCommand(sql, connection);
                List<Szamla> eredmeny = new List<Szamla>();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    eredmeny.Add(new Szamla()
                    {
                        Id = reader.GetInt32("Id"),
                        Szolgaltatasazon = reader.GetInt32("SzolgaltatasAzon"),
                        Szolgaltatorovid = reader.GetString("SzolgaltatoRovid"),
                        Tol = reader.GetDateTime("Tol"),
                        Ig = reader.GetDateTime("Ig"),
                        Osszeg = reader.GetInt32("Osszeg"),
                        Hatarido = reader.GetDateTime("Hatarido"),
                        Befizetve = reader.GetDateTime("Befizetve"),
                        Megjegyzes = reader.GetString("Megjegyzes")


                    });
                }
                connection.Close();
                return eredmeny;
            }
            catch (Exception)
            {
                //Console.WriteLine("Hiba történt: " + ex.Message);
                return new List<Szamla>();
            }
        }

        public Szamla GetSzamlaById(int id)
        {
            MySqlConnection connection = new MySqlConnection();
            string connectionString = "SERVER =localhost;DATABASE=kockasfuzet;UID=root;PASSWORD=;";
            connection.ConnectionString = connectionString;
            try
            {
                connection.Open();
                string sql = "SELECT * FROM `szamla` WHERE `Id` = @Id";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", id);
                Szamla eredmeny = new Szamla();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    eredmeny.Id = reader.GetInt32("Id");
                    eredmeny.Szolgaltatasazon = reader.GetInt32("SzolgaltatasAzon");
                    eredmeny.Szolgaltatorovid = reader.GetString("SzolgaltatoRovid");
                    eredmeny.Tol = reader.GetDateTime("Tol");
                    eredmeny.Ig = reader.GetDateTime("Ig");
                    eredmeny.Osszeg = reader.GetInt32("Osszeg");
                    eredmeny.Hatarido = reader.GetDateTime("Hatarido");
                    eredmeny.Befizetve = reader.GetDateTime("Befizetve");
                    eredmeny.Megjegyzes = reader.GetString("Megjegyzes");

                }
                connection.Close();
                return eredmeny;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string CreateSzamla(Szamla szamla)
        {
            MySqlConnection connection = new MySqlConnection();
            string connectionString = "SERVER =localhost;DATABASE=kockasfuzet;UID=root;PASSWORD=;";
            connection.ConnectionString = connectionString;
            try
            {
                connection.Open();
                string sql = "INSERT INTO `szamla`(`Id`, `SzolgaltatasAzon` ,`SzolgaltatoRovid`, `Tol`, `Ig`, `Osszeg`, `Hatarido`, `Befizetve`, `Megjegyzes`) VALUES (@Id,@Szolgaltatasazon,@SzolgaltatoRovid,@Tol,@Ig,@Osszeg,@Hatarido,@Befizetve,@Megjegyzes)";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", szamla.Id);
                command.Parameters.AddWithValue("@SzolgaltatasAzon", szamla.Szolgaltatasazon);
                command.Parameters.AddWithValue("@SzolgaltatoRovid", szamla.Szolgaltatorovid);
                command.Parameters.AddWithValue("@Tol", szamla.Tol);
                command.Parameters.AddWithValue("@Ig", szamla.Ig);
                command.Parameters.AddWithValue("@Osszeg", szamla.Osszeg);
                command.Parameters.AddWithValue("@Hatarido", szamla.Hatarido);
                command.Parameters.AddWithValue("@Befizetve", szamla.Befizetve);
                command.Parameters.AddWithValue("@Megjegyzes", szamla.Megjegyzes);
                int sorokSzama = command.ExecuteNonQuery();
                connection.Close();
                string valasz = sorokSzama > 0 ? "Sikeres rögzítés" : "Sikertelen rögzítés";
                return valasz;
            }
            catch (Exception ex)
            {
                return "Hiba történt: " + ex.Message;
            }
        }

        public string UpdateSzamla(Szamla szamla)
        {
            MySqlConnection connection = new MySqlConnection();
            string connectionString = "SERVER =localhost;DATABASE=kockasfuzet;UID=root;PASSWORD=;";
            connection.ConnectionString = connectionString;
            try
            {
                connection.Open();
                string sql = "UPDATE `szamla` SET `SzolgaltatasAzon` = @SzolgaltatasAzon, `SzolgaltatoRovid` = @SzolgaltatoRovid, `Tol` = @Tol, `Ig` = @Ig, `Osszeg` = @Osszeg, `Hatarido` = @Hatarido, `Befizetve` = @Befizetve, `Megjegyzes` = @Megjegyzes WHERE `Id` = @Id";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", szamla.Id);
                command.Parameters.AddWithValue("@SzolgaltatasAzon", szamla.Szolgaltatasazon);
                command.Parameters.AddWithValue("@SzolgaltatoRovid", szamla.Szolgaltatorovid);
                command.Parameters.AddWithValue("@Tol", szamla.Tol);
                command.Parameters.AddWithValue("@Ig", szamla.Ig);
                command.Parameters.AddWithValue("@Osszeg", szamla.Osszeg);
                command.Parameters.AddWithValue("@Hatarido", szamla.Hatarido);
                command.Parameters.AddWithValue("@Befizetve", szamla.Befizetve);
                command.Parameters.AddWithValue("@Megjegyzes", szamla.Megjegyzes);
                int sorokSzama = command.ExecuteNonQuery();
                connection.Close();
                string valasz = sorokSzama > 0 ? "Sikeres módosítás" : "Sikertelen módosítás";
                return valasz;
            }
            catch (Exception ex)
            {
                return "Hiba történt: " + ex.Message;
            }
        }

        public string DeleteSzamla(int id)
        {
            MySqlConnection connection = new MySqlConnection();
            string connectionString = "SERVER =localhost;DATABASE=kockasfuzet;UID=root;PASSWORD=;";
            connection.ConnectionString = connectionString;
            try
            {
                connection.Open();
                string sql = "DELETE FROM `szamla` WHERE `Id` = @Id";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", id);
                int sorokSzama = command.ExecuteNonQuery();
                connection.Close();
                string valasz = sorokSzama > 0 ? "Sikeres törlés" : "Sikertelen törlés";
                return valasz;
            }
            catch (Exception ex)
            {
                return "Hiba történt: " + ex.Message;
            }
        }
    }

}
