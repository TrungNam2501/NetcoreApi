using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManGnurt.DataAccess.Class
{
    public class PersonClass
    {
        private int Id { get; set; } = 4;
        private string First_Name { get; set; } = "Trung";

        private string Last_Name { get; set; } = "Nam";

        private string Full_Name { get; set; } = "Trung Nam";
       
        public int Age { get; set; }
        public string Address { get; set; }
        public PersonClass()
        {
        }
        public int GetId()
        {
            return Id;
        }  
        
        public PersonClass(string first_Name, string last_Name, int age, string address)
        {
            First_Name = first_Name;
            Last_Name = last_Name;
            Age = age;
            Address = address;
        }

        public string GetFullName()
        {
            //return $"{First_Name} {Last_Name}";
            return Full_Name;
        }
    }
}
