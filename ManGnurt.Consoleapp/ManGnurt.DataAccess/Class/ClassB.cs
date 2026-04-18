using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManGnurt.DataAccess.Class
{
    internal class ClassB
    {
        public void MethodB()
        {
                var classA = new ClassA();
                classA.MethodA();
        }
    }
}
