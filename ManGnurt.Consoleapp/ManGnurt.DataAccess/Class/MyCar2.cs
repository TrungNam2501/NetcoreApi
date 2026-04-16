using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManGnurt.DataAccess.Class
{
    public sealed class MyCar2
    {
        public void Display()
        {
            var car = new MyCar(2, "Toyota", "Camry", 2020, "Red");
            Console.WriteLine("This is MyCar2 class.");
        }
    }
}
