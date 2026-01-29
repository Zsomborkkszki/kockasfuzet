using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kockasfuzet.Models
{
    internal class Szamla
    {
        int Id;
        int SzolgaltatasAzon;
        string SzolgaltatoRovid;
        DateTime Tol;
        DateTime Ig;
        int Osszeg;
        DateTime Hatarido;
        DateTime Befizetve;
        string Megjegyzes;

        public Szamla(int id, int szolgaltatasAzon, string szolgaltatoRovid, DateTime tol, DateTime ig, int osszeg, DateTime hatarido, DateTime befizetve, string megjegyzes)
        {
            Id = id;
            SzolgaltatasAzon = szolgaltatasAzon;
            SzolgaltatoRovid = szolgaltatoRovid;
            Tol = tol;
            Ig = ig;
            Osszeg = osszeg;
            Hatarido = hatarido;
            Befizetve = befizetve;
            Megjegyzes = megjegyzes;
        }

        public int Id1 { get => Id; set => Id = value; }
        public int SzolgaltatasAzon1 { get => SzolgaltatasAzon; set => SzolgaltatasAzon = value; }
        public string SzolgaltatoRovid1 { get => SzolgaltatoRovid; set => SzolgaltatoRovid = value; }
        public DateTime Tol1 { get => Tol; set => Tol = value; }
        public DateTime Ig1 { get => Ig; set => Ig = value; }
        public int Osszeg1 { get => Osszeg; set => Osszeg = value; }
        public DateTime Hatarido1 { get => Hatarido; set => Hatarido = value; }
        public DateTime Befizetve1 { get => Befizetve; set => Befizetve = value; }
        public string Megjegyzes1 { get => Megjegyzes; set => Megjegyzes = value; }
    
        public Szamla() { }
    }
}
