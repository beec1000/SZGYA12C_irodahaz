using irodahaz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace irdoahaz
{
    class Program
    {
        static int F8(List<Iroda> i)
        {
            var x = 

            return x;
        }

        public static void Main(string[] args)
        {
            var irodak = new List<Iroda>();

            var sr = new StreamReader(@"..\..\..\src\irodahaz.txt");

            while (!sr.EndOfStream) 
            { 
                irodak.Add(new Iroda(sr.ReadLine()));
            }

            foreach (var i in irodak)
            {
                Console.WriteLine($"Kód: {i.Id}, Kezdeti év: {i.KezdetEv}, Létszám: {string.Join(" ", i.IrodaLetszam)}");
            }

            Console.WriteLine($"A legtöbb dolgozó {F8(irodak)}. emeleten van.");

        }
        
    }
}