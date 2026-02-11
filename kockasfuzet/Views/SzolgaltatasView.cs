using Kockasfuzet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kockasfuzet.Views
{
    internal class SzolgaltatasView
    {
        public void ShowSzolgaltatas(Szolgaltatas szolgaltatas)
        {
            Console.WriteLine($"Id: {szolgaltatas.Id}");
            Console.WriteLine($"Név: {szolgaltatas.Nev}");
        }

        public void ShowSzolgaltatasList(List<Szolgaltatas> szolgaltataslista)
        {
            Console.WriteLine("|-------------------+--------------------|");
            Console.WriteLine("|     Azonosító     |         Név        |");
            Console.WriteLine("|-------------------+--------------------|");
            foreach (Szolgaltatas szolgaltatas in szolgaltataslista)
            {
                Console.WriteLine(SzolgaltatasToRow(szolgaltatas));
            }
            Console.WriteLine("|-------------------+--------------------|");
        }

        public static string SzolgaltatasToRow(Szolgaltatas szolgaltatas)
        {
            string row = "|";
            row += szolgaltatas.Id;
            row += new string(' ', 18) + "|";
            row += szolgaltatas.Nev + new string(' ', 18 - szolgaltatas.Nev.Length + 1) + " |";
            return row;
        }
    }
}
