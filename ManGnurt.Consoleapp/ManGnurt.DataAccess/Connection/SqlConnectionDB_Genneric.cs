using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManGnurt.DataAccess.Connection
{
    public class SqlConnectionDB_Genneric: GenericConnectionDatabase<SqlConnection>
    {
        SqlConnection _sqlConnection;
        public override SqlConnection DoConnect()
        {
            var connectString = System.Configuration.ConfigurationManager.ConnectionStrings["TrunngNamDBconnect"].ConnectionString ?? "";
            _sqlConnection = new SqlConnection(connectString);

            if (_sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            return _sqlConnection;

        }
    }
}
