using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kockasfuzet.Models
{
    internal class Szolgaltato
    {
        string RovidNev;
        string Nev;
        string Ugyfelszolg;

        public Szolgaltato(string rovidNev, string nev, string ugyfelszolg)
        {
            RovidNev = rovidNev;
            Nev = nev;
            Ugyfelszolg = ugyfelszolg;
        }

        public string RovidNev1 { get => RovidNev; set => RovidNev = value; }
        public string Nev1 { get => Nev; set => Nev = value; }
        public string Ugyfelszolg1 { get => Ugyfelszolg; set => Ugyfelszolg = value; }
        
        public Szolgaltato() { }
    }
}
