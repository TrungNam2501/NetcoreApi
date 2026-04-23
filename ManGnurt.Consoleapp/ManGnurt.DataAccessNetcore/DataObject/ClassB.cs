using System;
using System.Collections.Generic;
using System.Text;

namespace ManGnurt.DataAccessNetcore.DataObject
{
    public class ClassB
    {
        public ClassB() { }
        public void HamB()
        {
            var classA = new ClassA();  
            classA.HamA();
        }
    }
}
