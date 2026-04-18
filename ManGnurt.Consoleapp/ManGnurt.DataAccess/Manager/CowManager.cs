using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManGnurt.DataAccess.Interface;

namespace ManGnurt.DataAccess.Manager
{
    public class CowManager:IAnimal
    {
        public void Eat()
        {
            Console.WriteLine("Cow is eating grass.");
        }
        public void Eat2() { Console.WriteLine(""); }
    }
    
}
