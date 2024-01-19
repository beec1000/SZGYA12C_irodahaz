using irodahaz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace irodahaz
{
    class Program
    {
        static Iroda F8(List<Iroda> i)
        {
            var x = i.MaxBy(d => d.IrodaLetszam.Sum());
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

            Console.WriteLine("8. feladat");
            Console.WriteLine($"A legtöbb dolgozó {F8(irodak)}. emeleten van.");

            Console.WriteLine("9. feladat");
            foreach (var i in irodak)
            {
                foreach (var j in i.IrodaLetszam)
                {
                    if (j == 9)
                    {
                        Console.WriteLine($"{i.Id},");
                    }
                }
            }

        }
        
    }
}