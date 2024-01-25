﻿using irodahaz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace irodahaz
{
    class Program
    {
        static int F8(List<Iroda> i)
        {
            var x = i.MaxBy(d => d.IrodaLetszam.Sum()).Sorszam;
            return x;
        }

        static Iroda F9(List<Iroda> i)
        {
            var x = i.First(d => d.IrodaLetszam.Contains(9));
            return x;
        }

        static int F10(List<Iroda> i)
        {
            var x = i.Sum(d => d.IrodaLetszam.Where(dd => dd > 5).Count());
            return x;
        }

        static IEnumerable<Iroda> F11(List<Iroda> i)
        {
            var x = i.Where(d => d.IrodaLetszam.Contains(0)).ToList();
            return x;
        }

        static double F12(List<Iroda> i)
        {
            var x = i.Where(d => d.Id == ("LOGMEIN")).Average(dd => dd.IrodaLetszam.Sum());
            return x;
        }

        public static void Main(string[] args)
        {
            var irodak = new List<Iroda>();

            using var sr = new StreamReader(@"..\..\..\src\irodahaz.txt");
            for (int i = 1; !sr.EndOfStream; i++)
            {
                irodak.Add(new Iroda(i, sr.ReadLine()));
            }

            for (int i = 0; i < irodak.Count; i++)
            {
                Console.WriteLine($"{i + 1} {irodak[i]}");
            }

            Console.WriteLine("8. feladat");
            Console.WriteLine($"A legtöbb dolgozó {F8(irodak)}. emeleten van.");

            Console.WriteLine("9. feladat");
            if (F9(irodak) == null)
            {
                Console.WriteLine("HIBA 404!!! nincs ilyen iroda");
            }
            else
            {
                Console.WriteLine($"Az iroda kódja {F9(irodak).Id}, Iroda Sorszáma: {F9(irodak).Sorszam}.");
            }

            Console.WriteLine("10. feladat");
            Console.WriteLine($"Ötnél többen {F10(irodak)} irodában vannak.");

            //11. feladat    
            var sw11 = new StreamWriter(@"..\..\..\src\irodahazF11.txt");
            foreach (var i in F11(irodak))
            {
                sw11.WriteLine($"{i.Id} {i.Sorszam}. Emeleten {string.Join(", ", i.IrodaLetszam.Where(d => d == 0).Count())}. Irodában/Irodákban");
            }

            Console.WriteLine("12. feladat");
            Console.WriteLine($"Az átlagos dolgozók száma: {F12(irodak)}");

            //13. feladat
            

            sw11.Close();

        }
        
    }
}