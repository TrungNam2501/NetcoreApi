using ManGnurt.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManGnurt.DataAccess.Class
{
    public class MayTinhDell : MayViTinh, IAnimal
    {
        public void Eat()
        {
            throw new NotImplementedException();
        }
    }
}
