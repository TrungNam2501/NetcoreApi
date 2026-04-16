using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManGnurt.DataAccess.Interface
{
    public class AnimalManager:IAnimal
    {
        public void Eat()
        {
            Console.WriteLine("Animal is eating.");
        }
    }  
    
}
