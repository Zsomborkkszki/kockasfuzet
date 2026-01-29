using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kockasfuzet.Models
{
    internal class Szolgaltatas
    {
        int Id;
        string Nev;

        public Szolgaltatas(int id, string nev)
        {
            Id = id;
            Nev = nev;
        }

        public int Id1 { get => Id; set => Id = value; }
        public string Nev1 { get => Nev; set => Nev = value; }

        public Szolgaltatas() { }
    }
}
