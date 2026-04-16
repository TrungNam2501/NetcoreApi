using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManGnurt.DataAccess.AbstractClass
{
    public class Bird :Animal
    {
      
        public override void Eat()
        {
            Console.WriteLine("Bird is pecking seeds.");
        }
        public override void MakeSound()
        {
            Console.WriteLine("Bird says: Chirp!");
        }
    }
}
