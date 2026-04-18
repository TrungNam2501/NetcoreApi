using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChimAll.Models
{
    public class Bird
    {
        public string Name { get; set; }

        public Bird(string name)
        {
            Name = name;
        }

        public void Eat()
        {
            Console.WriteLine($"{Name} đang ăn");
        }
    }
}
