using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kockasfuzet.Models
{
    internal class Szolgaltato
    {
        string rovidNev;
        string nev;
        string ugyfelszolg;

        public Szolgaltato(string rovidNev, string nev, string ugyfelszolg)
        {
            this.rovidNev = rovidNev;
            this.nev = nev;
            this.ugyfelszolg = ugyfelszolg;
        }

        public string RovidNev { get => rovidNev; set => rovidNev = value; }
        public string Nev { get => nev; set => nev = value; }
        public string Ugyfelszolg { get => ugyfelszolg; set => ugyfelszolg = value; }
        
        public Szolgaltato() { }

        public override string ToString()
        {
            return $"         {RovidNev}              {Nev}              {Ugyfelszolg}";
        }
    }
}
