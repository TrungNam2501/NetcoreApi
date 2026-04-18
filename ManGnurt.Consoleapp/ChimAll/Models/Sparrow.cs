using ChimAll.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChimAll.Models
{
    public class Sparrow : Bird, IFlyable
    {
        public Sparrow(string name) : base(name) { }

        public void Fly()
        {
            Console.WriteLine($"{Name} đang bay trên trời");
        }
    }
}
