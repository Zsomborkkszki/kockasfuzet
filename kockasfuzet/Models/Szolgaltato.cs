using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kockasfuzet.Models
{
    internal class Szolgaltato
    {
        string rovidnev;
        string nev;
        string ugyfelszolgalat;

        public Szolgaltato(string rovidnev, string nev, string ugyfelszolgalat)
        {
            this.rovidnev = rovidnev;
            this.nev = nev;
            this.ugyfelszolgalat = ugyfelszolgalat;
        }
        public Szolgaltato() { }

        public string RovidNev { get => rovidnev; set => rovidnev = value; }
        public string Nev { get => nev; set => nev = value; }
        public string Ugyfelszolgalat { get => ugyfelszolgalat; set => ugyfelszolgalat = value; }
    }
}