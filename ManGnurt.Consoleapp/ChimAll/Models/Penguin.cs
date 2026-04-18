using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChimAll.Models
{
    public class Penguin : Bird
    {
        public Penguin(string name) : base(name) { }

        public void Swim()
        {
            Console.WriteLine($"{Name} đang bơi dưới nước");
        }
    }
}
