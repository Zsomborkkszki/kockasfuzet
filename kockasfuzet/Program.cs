using Kockasfuzet.Controllers;
using Kockasfuzet.Models;
using Kockasfuzet.Views;
using System;
using System.Collections.Generic;

namespace Kockasfuzet
{
    internal class Program
    {
        static int cPoint = 0;
        static ConsoleColor activeForeground = ConsoleColor.White;
        static ConsoleColor activeBack = ConsoleColor.DarkGray;

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Fomenu();
        }

        static void Fomenu()
        {
            cPoint = 0;
            bool kilepes = false;

            do
            {
                bool selected = false;

                do
                {
                    ShowMenu(cPoint);
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.Enter:
                            selected = true;
                            break;
                        case ConsoleKey.UpArrow:
                            if (cPoint > 0) cPoint--;
                            break;
                        case ConsoleKey.DownArrow:
                            if (cPoint < 3) cPoint++;
                            break;
                        case ConsoleKey.Escape:
                            cPoint = 3;
                            selected = true;
                            break;
                    }
                } while (!selected);

                Console.CursorVisible = true; 
                Console.Clear();

                switch (cPoint)
                {
                    case 0: // Szolgáltatók
                        KezelSzolgaltatok();
                        break;

                    case 1: // Szolgáltatások
                        KezelSzolgaltatasok();
                        break;

                    case 2: // Számlák
                        KezelSzamlak();
                        break;

                    case 3: // Kilépés
                        Rendezes.WriteCentered("Biztosan kilép? (Enter: Igen / Esc: Nem)");
                        if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                        {
                            kilepes = true;
                        }
                        break;
                }

                Console.CursorVisible = false;

            } while (!kilepes);
        }

        static void ShowMenu(int cPoint)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Rendezes.WriteCentered("=== KOCKÁSFÜZET MENÜ ===");
            Console.WriteLine();

            void WriteOption(string text, int index)
            {
                if (cPoint == index)
                {
                    Console.BackgroundColor = activeBack;
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = activeForeground;
                }
                Rendezes.WriteCentered($"  {text}  ");
                Console.ResetColor(); // Visszaállítjuk a színeket a sor után
            }

            WriteOption("Szolgáltatók kezelése", 0);
            WriteOption("Szolgáltatások kezelése", 1);
            WriteOption("Számlák kezelése", 2);
            Console.WriteLine(); // Kis elválasztás
            WriteOption("Kilépés", 3);
        }

        static void KezelSzolgaltatok()
        {
            Console.Clear();
            List<Szolgaltato> listaAdatbazisbol = new SzolgaltatoController().GetSzolgaltatoList();
            new SzolgaltatoView().ShowSzolgaltatoList(listaAdatbazisbol);

            Console.WriteLine("\n--- Műveletek ---");
            Console.WriteLine("1. Új szolgáltató rögzítése");
            Console.WriteLine("2. Szolgáltató módosítása");
            Console.WriteLine("3. Szolgáltató törlése");
            Console.WriteLine("Bármely más gomb: Vissza a főmenübe");

            string altvalasz = Console.ReadLine();
            switch (altvalasz)
            {
                case "1":
                    try
                    {
                        Console.Clear();
                        new SzolgaltatoView().ShowSzolgaltatoList(listaAdatbazisbol);
                        Console.Write("Kérem adja meg a rövid nevét a szolgáltatónak: ");
                        string rovidnev = Console.ReadLine();
                        Console.Write("Kérem adja meg a teljes nevét a szolgáltatónak: ");
                        string nev = Console.ReadLine();
                        Console.Write("Kérem adja meg az ügyfélszolgálat címét: ");
                        string ugyfelszolgalat = Console.ReadLine();
                        Szolgaltato ujSzolgaltato = new Szolgaltato()
                        {
                            RovidNev = rovidnev,
                            Nev = nev,
                            Ugyfelszolgalat = ugyfelszolgalat
                        };
                        new SzolgaltatoController().CreateSzolgaltato(ujSzolgaltato);
                        Console.WriteLine("Sikeres rögzítés!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Hiba történt: " + ex.Message);
                    }
                    break;

                case "2":
                    try
                    {
                        Console.Clear();
                        new SzolgaltatoView().ShowSzolgaltatoList(listaAdatbazisbol);
                        Console.Write("Kérem adja meg a módosítani kívánt szolgáltató rövid nevét: ");
                        string eredetirovidnev = Console.ReadLine();
                        Console.Write("Új rövid név: ");
                        string modrovidnev = Console.ReadLine();
                        Console.Write("Új teljes név: ");
                        string modnev = Console.ReadLine();
                        Console.Write("Új ügyfélszolgálat címe: ");
                        string modugyfelszolgalat = Console.ReadLine();
                        Szolgaltato modujSzolgaltato = new Szolgaltato()
                        {
                            RovidNev = modrovidnev,
                            Nev = modnev,
                            Ugyfelszolgalat = modugyfelszolgalat
                        };
                        new SzolgaltatoController().UpdateSzolgaltato(modujSzolgaltato, eredetirovidnev);
                        Console.WriteLine("Sikeres módosítás!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Hiba történt: " + ex.Message);
                    }
                    break;

                case "3":
                    try
                    {
                        Console.Clear();
                        new SzolgaltatoView().ShowSzolgaltatoList(listaAdatbazisbol);
                        Console.Write("Kérem, adja meg a törölni kívánt szolgáltató rövid nevét: ");
                        string torolrovidnev = Console.ReadLine();
                        Szolgaltato torolSzolgaltato = new Szolgaltato()
                        {
                            RovidNev = torolrovidnev
                        };
                        new SzolgaltatoController().DeleteSzolgaltato(torolSzolgaltato);
                        Console.WriteLine("Sikeres törlés!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Hiba történt: " + ex.Message);
                    }
                    break;
            }
            Rendezes.Varakozas();
        }
        static void KezelSzolgaltatasok()
        {
            Console.Clear();
            List<Szolgaltatas> listaAdatbazisbol2 = new SzolgaltatasController().GetSzolgaltatasList();
            new SzolgaltatasView().ShowSzolgaltatasList(listaAdatbazisbol2);

            Console.WriteLine("\n--- Műveletek ---");
            Console.WriteLine("1. Új szolgáltatás rögzítése");
            Console.WriteLine("2. Szolgáltatás módosítása");
            Console.WriteLine("3. Szolgáltatás törlése");
            Console.WriteLine("Bármely más gomb: Vissza a főmenübe");

            string altvalasz = Console.ReadLine();
            switch (altvalasz)
            {
                case "1":
                    try
                    {
                        Console.Clear();
                        new SzolgaltatasView().ShowSzolgaltatasList(listaAdatbazisbol2);
                        Console.Write("Kérem adja meg a nevét a szolgáltatásnak: ");
                        string nev = Console.ReadLine();
                        Szolgaltatas ujSzolgaltatas = new Szolgaltatas()
                        {
                            Nev = nev,
                        };
                        new SzolgaltatasController().CreateSzolgaltatas(ujSzolgaltatas);
                        Console.WriteLine("Sikeres rögzítés!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Hiba történt: " + ex.Message);
                    }
                    break;

                case "2":
                    try
                    {
                        Console.Clear();
                        new SzolgaltatasView().ShowSzolgaltatasList(listaAdatbazisbol2);
                        Console.Write("Kérem adja meg a módosítani kívánt szolgáltatás sorszámát: ");
                        int modid = int.Parse(Console.ReadLine());
                        Console.Write("Kérem adja meg az új nevét a szolgáltatásnak: ");
                        string modnev = Console.ReadLine();
                        Szolgaltatas modujSzolgaltatas = new Szolgaltatas()
                        {
                            Id = modid,
                            Nev = modnev,
                        };
                        new SzolgaltatasController().UpdateSzolgaltatas(modujSzolgaltatas);
                        Console.WriteLine("Sikeres módosítás!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Hiba történt: " + ex.Message);
                    }
                    break;

                case "3":
                    try
                    {
                        Console.Clear();
                        new SzolgaltatasView().ShowSzolgaltatasList(listaAdatbazisbol2);
                        Console.Write("Kérem, adja meg a törölni kívánt szolgáltatás sorszámát: ");
                        int torolId = int.Parse(Console.ReadLine());
                        new SzolgaltatasController().DeleteSzolgaltatas(torolId);
                        Console.WriteLine("Sikeres törlés!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Hiba történt: " + ex.Message);
                    }
                    break;
            }
            Rendezes.Varakozas();
        }

        static void KezelSzamlak()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------- SZÁMLÁK -------");
            Console.ForegroundColor = ConsoleColor.White;
            List<Szamla> listaAdatbazisbol3 = new SzamlaController().GetSzamlaList();
            new SzamlaView().ShowSzamlaList(listaAdatbazisbol3);

            Console.WriteLine("\n--- Műveletek ---");
            Console.WriteLine("1. Új számla rögzítése");
            Console.WriteLine("2. Számla módosítása");
            Console.WriteLine("3. Számla törlése");
            Console.WriteLine("Bármely más gomb: Vissza a főmenübe");

            string altvalasz = Console.ReadLine();
            switch (altvalasz)
            {
                case "1":
                    try
                    {
                        Console.Clear();
                        
                        List<Szolgaltatas> listaSzolg = new SzolgaltatasController().GetSzolgaltatasList();
                        new SzolgaltatasView().ShowSzolgaltatasList(listaSzolg);

                        Console.Write("Kérem adja meg a szolgáltatás azonosítóját: ");
                        int szolgaltatasazon = int.Parse(Console.ReadLine());
                        Console.Write("Kérem adja meg a szolgáltató rövidnevét: ");
                        string szolgaltatorovnev = Console.ReadLine();
                        Console.Write("Kérem adja meg, hogy mikortól tartott: ");
                        DateTime tol = DateTime.Parse(Console.ReadLine());
                        Console.Write("Kérem adja meg, hogy meddig tartott: ");
                        DateTime ig = DateTime.Parse(Console.ReadLine());
                        Console.Write("Kérem, adja meg az összeget: ");
                        int osszeg = int.Parse(Console.ReadLine());
                        Console.Write("Kérem, adja meg a határidőt: ");
                        DateTime hatarido = DateTime.Parse(Console.ReadLine());
                        Console.Write("Kérem, adja meg a befizetés napját: ");
                        DateTime befizetve = DateTime.Parse(Console.ReadLine());
                        Console.Write("Kérem, adja meg a megjegyzést: ");
                        string megjegyzes = Console.ReadLine();

                        Szamla ujSzamla = new Szamla()
                        {
                            Szolgaltatasazon = szolgaltatasazon,
                            Szolgaltatorovid = szolgaltatorovnev,
                            Tol = tol,
                            Ig = ig,
                            Osszeg = osszeg,
                            Hatarido = hatarido,
                            Befizetve = befizetve,
                            Megjegyzes = megjegyzes
                        };
                        Console.WriteLine(new SzamlaController().CreateSzamla(ujSzamla));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Hiba történt: " + ex.Message);
                    }
                    break;

                case "2":
                    try
                    {
                        Console.Clear();
                        new SzamlaView().ShowSzamlaList(listaAdatbazisbol3);
                        Console.Write("Kérem adja meg a módosítani kívánt számla sorszámát: ");
                        int modint = int.Parse(Console.ReadLine());

                        
                        List<Szolgaltatas> listaSzolg = new SzolgaltatasController().GetSzolgaltatasList();
                        new SzolgaltatasView().ShowSzolgaltatasList(listaSzolg);

                        Console.Write("Kérem adja meg az új szolgáltatás azonosítóját: ");
                        int modszolgaltatasazon = int.Parse(Console.ReadLine());
                        Console.Write("Kérem adja meg az új szolgáltató rövidnevét: ");
                        string modszolgaltatorovnev = Console.ReadLine();
                        Console.Write("Kérem adja meg, hogy mikortól tartott: ");
                        DateTime modtol = DateTime.Parse(Console.ReadLine());
                        Console.Write("Kérem adja meg, hogy meddig tartott: ");
                        DateTime modig = DateTime.Parse(Console.ReadLine());
                        Console.Write("Kérem, adja meg az új összeget: ");
                        int modosszeg = int.Parse(Console.ReadLine());
                        Console.Write("Kérem, adja meg az új határidőt: ");
                        DateTime modhatarido = DateTime.Parse(Console.ReadLine());
                        Console.Write("Kérem, adja meg az új befizetés napját: ");
                        DateTime modbefizetve = DateTime.Parse(Console.ReadLine());
                        Console.Write("Kérem, adja meg az új megjegyzést: ");
                        string modmegjegyzes = Console.ReadLine();

                        Szamla modujSzamla = new Szamla()
                        {
                            Id = modint,
                            Szolgaltatasazon = modszolgaltatasazon,
                            Szolgaltatorovid = modszolgaltatorovnev,
                            Tol = modtol,
                            Ig = modig,
                            Osszeg = modosszeg,
                            Hatarido = modhatarido,
                            Befizetve = modbefizetve,
                            Megjegyzes = modmegjegyzes
                        };
                        new SzamlaController().UpdateSzamla(modujSzamla);
                        Console.WriteLine("Sikeres módosítás!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Hiba történt: " + ex.Message);
                    }
                    break;

                case "3":
                    try
                    {
                        Console.Clear();
                        new SzamlaView().ShowSzamlaList(listaAdatbazisbol3);
                        Console.Write("Kérem, adja meg a törölni kívánt számla sorszámát: ");
                        int torolssz = int.Parse(Console.ReadLine());
                        new SzamlaController().DeleteSzamla(torolssz);
                        Console.WriteLine("Sikeres törlés!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Hiba történt: " + ex.Message);
                    }
                    break;
            }
            Rendezes.Varakozas();
        }
    }

    public static class Rendezes
    {
        public static void WriteCentered(string text)
        {
            if (string.IsNullOrEmpty(text)) return;
            int windowWidth = Console.WindowWidth;
            int textLength = text.Length;
            int padding = (windowWidth - textLength) / 2;
            if (padding > 0)
            {
                Console.Write(new string(' ', padding));
            }
            Console.WriteLine(text);
        }

        public static void Varakozas()
        {
            Console.WriteLine("\nNyomjon ENTER-t a menübe való visszalépéshez...");
            Console.ReadLine();
        }
    }
}