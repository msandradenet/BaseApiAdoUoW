using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApiAdoUow.INFRA.Repository.SqlServer
{
    public class Repository
    {
        protected SqlConnection sqlConnection;
        protected SqlTransaction sqlTransaction;

        protected SqlCommand CreateCommand(string query)
        {
            return new SqlCommand(query, sqlConnection, sqlTransaction);
        }
    }
}
