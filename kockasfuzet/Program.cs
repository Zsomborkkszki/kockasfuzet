using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kockasfuzet.Controllers;
using kockasfuzet.Models;
using kockasfuzet.Views;

namespace kockasfuzet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---Főmenü---");
            Console.WriteLine("1. Szolgáltatók listázása");
            Console.WriteLine("2. Szolgáltató adatainak megtekintése");
            switch (Console.ReadLine())
            {
                case "1":
                    List<Szolgaltato> listaAdatbol = SzolgaltatoController.GetUserData();
                    SzolgaltatoView.ShowSzolgaltatoListBy(listaAdatbol);
                    break;
                case "2":
                    SzolgaltatoView.ShowSzolgaltatoBy(new Szolgaltato() { Nev = "Teszt Szolgáltató", RovidNev = "TSZ", Ugyfelszolg = "Teszt utca 1." });
                    break;
                default:
                    break;
            }
            
        }
    }
}
