using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dolgozo
{
    internal class Program
    {
        static Adatbazis db = new Adatbazis();
        static List<Dolgozo> dolgozok = new List<Dolgozo>();
        static void Main(string[] args)
        {
            dolgozok = db.GetAllDolgozo();
            feladat01();
            feladat02();
            feladat03();
            feladat04();
            Console.WriteLine("Program Vége!");
            Console.ReadLine();
        }

        private static void feladat04()
        {
            Console.WriteLine("4. Feladat");
            foreach (Dolgozo item in dolgozok.FindAll(a => a.reszleg.Equals("asztalosműhely")))
            {
                Console.WriteLine($"\t {item.nev} ");
            }
        }

        private static void feladat03()
        {
            Console.WriteLine("3. Feladat");
            foreach (var item in dolgozok.GroupBy(a => a.reszleg).Select(b => new { reszleg = b.Key, letszam = b.Count()}))
            {
                Console.WriteLine($"\t A {item.reszleg} részlegen lévők száma: {item.letszam} fő.");
            }
        }

        private static void feladat02()
        {
            Console.WriteLine("2. Feladat");
            Dolgozo legjobbanKereso= dolgozok.Find(a => a.ber == dolgozok.Max(b => b.ber));
            Console.WriteLine($"\t {legjobbanKereso.nev} keres legjobban {legjobbanKereso.ber}");
        }

        private static void feladat01()
        {
            Console.WriteLine("1. Feladat");
            Console.WriteLine($"Dolgozok száma: {dolgozok.Count} fő");
        }
    }
}
