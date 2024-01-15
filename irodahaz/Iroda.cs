using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irodahaz
{
    internal class Iroda
    {
        public string Id { get; set; }
        public int KezdetEv { get; set; }
        public List<int> IrodaLetszam { get; set; }

        public Iroda(string s)
        { 
            var v = s.Split(' ');
            this.Id = v[0];
            this.KezdetEv = int.Parse(v[1]);
            this.IrodaLetszam = new List<int>();
        }

        public void ToString()
        {
            Console.WriteLine($"Cég kódja: {this.Id}, Cég kezdeti éve: {this.KezdetEv}, Irodák létszáma: {this.IrodaLetszam}");
        }
    }
}
