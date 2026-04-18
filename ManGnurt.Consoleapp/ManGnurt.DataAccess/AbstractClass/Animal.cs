using ManGnurt.DataAccess.Class;
using ManGnurt.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManGnurt.DataAccess.AbstractClass
{
    public abstract class Animal : MyCar, IAnimal
    {
        public virtual string Name { get; set; }
        public abstract void Eat();
        public abstract void MakeSound();
        public virtual void Display()
        {
            Console.WriteLine("Name: {0}", Name);
        }
        public void Eat2()
        {
            throw new NotImplementedException();
        }

        public void MakeSound2()
        {
            throw new NotImplementedException();
        }
        public void CarMes()
        {
            var carMesss= new MyCar(1, "Honda", "Civic", 2019, "Blue");
        }

        
    }
}
