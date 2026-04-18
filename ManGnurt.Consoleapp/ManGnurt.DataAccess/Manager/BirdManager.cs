using ManGnurt.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManGnurt.DataAccess.Manager
{
    public class BirdManager:IAnimal
    {
        public void Eat()
        {
            Console.WriteLine("Bird is pecking seeds.");
        }

  

        public void Eat2()
        {
            Console.WriteLine("");
        }
    }
}
