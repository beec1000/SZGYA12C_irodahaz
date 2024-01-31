using irodahaz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace irodahaz
{
    class Program
    {
        static int F8(List<Iroda> i) => i.MaxBy(d => d.IrodaLetszam.Sum()).Sorszam;

        static Iroda F9(List<Iroda> i) => i.First(d => d.IrodaLetszam.Contains(9));

        static int F10(List<Iroda> i) => i.Sum(d => d.IrodaLetszam.Where(dd => dd > 5).Count());

        static List<string> F11(List<Iroda> i)
        {
            var x = i.Where(iroda => iroda.IrodaLetszam.All(szam => szam == 0)).Select(iroda => $"{iroda.Id} {iroda.Sorszam}").ToList();

            return x;
        }

        static double F12(List<Iroda> i) => i.Where(d => d.Id == ("LOGMEIN")).Average(dd => dd.IrodaLetszam.Sum());

        static int F14(List<Iroda> i) => i.Sum(d => d.IrodaLetszam.Sum());

        static int F15(List<Iroda> i) => i.Min(d => d.KezdetEv);

        static int F16(List<Iroda> i) => DateTime.Now.Year - i.Max(d => d.KezdetEv);


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
                sw11.WriteLine($"{i}");
            }

            Console.WriteLine("12. feladat");
            Console.WriteLine($"Az átlagos dolgozók száma: {F12(irodak)}");

            // 13. feladat
            sw11.WriteLine("Emelet | Dolgozók száma");
            foreach (var i in irodak)
            {
                sw11.WriteLine($"{i.Sorszam}. Emelet | {i.IrodaLetszam.Count(dd => dd > 0)} dolgozó");
            }

            sw11.Close();


            Console.WriteLine("14. feladat");
            Console.WriteLine($"Az irodaházban összesen {F14(irodak)} ember dolgozik.");

            Console.WriteLine("15. feladat");
            Console.WriteLine($"Az első irodabérlés {F15(irodak)}-ban/ben törtnént.");

            Console.WriteLine("16. feladat");
            Console.WriteLine($"{F16(irodak)} éve nem történt új irodabérlés.");
        }
    }
}