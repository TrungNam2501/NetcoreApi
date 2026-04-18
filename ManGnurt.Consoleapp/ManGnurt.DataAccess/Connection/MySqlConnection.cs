using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManGnurt.DataAccess.Connection
{
    internal class MySqlConnection:ConnectionBase
    {
        public override void ConnectToDB()
        {
            Console.WriteLine("Connected to MySQL Database");
        }
    }
}
