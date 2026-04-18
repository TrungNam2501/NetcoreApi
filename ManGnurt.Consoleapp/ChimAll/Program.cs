using ChimAll.Interfaces;
using ChimAll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChimAll
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            List<Bird> birds = new List<Bird>()
            {
                new Sparrow("Chim sẻ"),
                new Penguin("Chim cánh cụt")
            };

            Console.WriteLine("=== TẤT CẢ CHIM ===");
            foreach (var b in birds)
            {
                b.Eat();
            }

            Console.WriteLine("\n=== CHIM BIẾT BAY ===");
            List<IFlyable> flyingBirds = new List<IFlyable>()
            {
                new Sparrow("Chim sẻ 2")
            };

            foreach (var f in flyingBirds)
            {
                f.Fly();
            }

            Console.WriteLine("\n=== CHIM CÁNH CỤT ===");
            Penguin p = new Penguin("Pingu");
            p.Swim();
        }
    }
}
