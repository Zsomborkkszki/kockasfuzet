using Kockasfuzet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kockasfuzet.Views
{
    internal class SzolgaltatoView
    {
        public SzolgaltatoView() { }

        public void ShowSzolgaltato(Szolgaltato szolgaltato)
        {
            Console.WriteLine($"Rövid név: {szolgaltato.RovidNev}");
            Console.WriteLine($"Név: {szolgaltato.Nev}");
            Console.WriteLine($"Ügyfélszolgálat");
            Console.WriteLine($"Cím: {szolgaltato.Ugyfelszolgalat}");
            Console.WriteLine("Telefon:");
        }

        public void ShowSzolgaltatoList(List<Szolgaltato> szolgaltatolista)
        {
            Console.WriteLine("|--------+--------------------------------+----------------------------------------------|");
            Console.WriteLine("|RövidNév|               Név              |                 Ügyfélszolgálat              |");
            Console.WriteLine("|        |                                |               Cím              |   Telefon   |");
            Console.WriteLine("|--------|--------------------------------|--------------------------------|-------------|");
            foreach (Szolgaltato szolgaltato in szolgaltatolista)
            {
                Console.WriteLine(SzolgaltatoToRow(szolgaltato));
            }
            Console.WriteLine("|--------+--------------------------------+----------------------------------------------|");
        }

        public static string SzolgaltatoToRow(Szolgaltato szolgaltato)
        {
            string row = "|";
            if (szolgaltato.RovidNev.Length < 9) row += szolgaltato.RovidNev;
            row += szolgaltato.RovidNev.Length < 9 ? new string(' ', 8 - szolgaltato.RovidNev.Length) + "|" : szolgaltato.RovidNev.Substring(0, 5) + "...|";
            row += szolgaltato.Nev.Length < 30 ? szolgaltato.Nev + new string(' ', 30 - szolgaltato.Nev.Length + 1) + " |" :
                szolgaltato.Nev.Substring(0, 28) + "... |";
            row += szolgaltato.Ugyfelszolgalat.Length < 30 ? szolgaltato.Ugyfelszolgalat + new string(' ', 30 - szolgaltato.Ugyfelszolgalat.Length + 1) + " |             |" : szolgaltato.Ugyfelszolgalat.Substring(0, 28) + "... |             |";
            return row;
        }
    }
}
