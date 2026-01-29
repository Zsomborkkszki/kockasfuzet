using System;
using System.Collections.Generic;
using kockasfuzet.Models;

namespace kockasfuzet.Views
{
    internal class SzolgaltatoView
    {
        public SzolgaltatoView() { }

        static public void ShowSzolgaltatoBy(Szolgaltato szolgaltato)
        {
            Console.WriteLine($"Rövid név:      {szolgaltato.RovidNev}");
            Console.WriteLine($"Név:            {szolgaltato.Nev}");
            Console.WriteLine($"--- Ügyfélszolgálat ---");
            Console.WriteLine($"Cím:            {szolgaltato.Ugyfelszolg}");
            //.WriteLine($"Telefon:        {szolgaltato.Telefon}");
        }

        static public void ShowSzolgaltatoListBy(List<Szolgaltato> szolgaltatoList)
        {
            // Oszlopok szélességeinek definiálása a fejléc alapján
            // RövidNév: 14, Név: 24, Cím (megnövelve): 40, Telefon: 14

            Console.WriteLine("|-{0,-14}-|-{1,-24}-|-{2,-40}-|-{3,-14}-|",
                new string('-', 14), new string('-', 24), new string('-', 40), new string('-', 14));

            Console.WriteLine("| {0,-14} | {1,-24} | {2,-40} | {3,-14} |",
                "RövidNév", "Név", "Cím (Ügyfélszolg.)", "Telefon");

            Console.WriteLine("|-{0,-14}-|-{1,-24}-|-{2,-40}-|-{3,-14}-|",
                new string('-', 14), new string('-', 24), new string('-', 40), new string('-', 14));

            foreach (var sz in szolgaltatoList)
            {
                // A hosszú szövegek levágása, hogy ne essenek szét az oszlopok
                string rovidNev = Levag(sz.RovidNev, 14);
                string nev = Levag(sz.Nev, 24);
                string cim = Levag(sz.Ugyfelszolg, 40); // Itt a cím, ami hosszú lehet
               // string tel = Levag(sz.Telefon, 14);     // Feltételezve, hogy van Telefon mező

                Console.WriteLine("| {0,-14} | {1,-24} | {2,-40} | {3,-14} |",
                    rovidNev, nev, cim, "teszt");
            }

            Console.WriteLine("|-{0,-14}-|-{1,-24}-|-{2,-40}-|-{3,-14}-|",
                new string('-', 14), new string('-', 24), new string('-', 40), new string('-', 14));
        }

        // Segédfüggvény a hosszú szövegek levágásához
        static private string Levag(string szoveg, int maxHossz)
        {
            if (string.IsNullOrEmpty(szoveg)) return "";
            if (szoveg.Length <= maxHossz) return szoveg;

            // Ha hosszabb, levágjuk és teszünk a végére pontokat (ha kifér)
            return szoveg.Substring(0, maxHossz - 3) + "...";
        }
    }
}