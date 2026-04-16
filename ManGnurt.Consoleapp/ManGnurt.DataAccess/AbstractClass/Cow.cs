using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManGnurt.DataAccess.AbstractClass
{
    public class Cow : Animal
    {

     
        public override void Eat()
        {
            Console.WriteLine("Cow is eating grass.");
        }
        public override void MakeSound()
        {
            Console.WriteLine("Cow says: Moo!");
        }
    }
}
