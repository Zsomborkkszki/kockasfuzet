using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kockasfuzet.Models
{
    internal class Szolgaltatas
    {
        int id;
        string nev;

        public Szolgaltatas(int azon, string nev)
        {
            this.id = azon;
            this.nev = nev;
        }
        public Szolgaltatas() { }

        public int Id { get => id; set => id = value; }
        public string Nev { get => nev; set => nev = value; }

        public override string ToString()
        {
            return $"Id: {Id},Név: {Nev}";
        }
    }
}