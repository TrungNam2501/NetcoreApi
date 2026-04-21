using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManGnurt.DataAccess.Connection
{
    public abstract class GenericConnectionDatabase<T>
    {
        public abstract T DoConnect();

    }
}
