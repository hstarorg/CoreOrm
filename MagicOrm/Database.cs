using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MagicOrm
{
    public class Database
    {
        public Database(string connectionStringName )
        {
            // Use first?
            if (string.IsNullOrEmpty(connectionStringName))
            {
              //  onnectionStringName = ConfigurationManager.ConnectionStrings[0].ProviderName
            }
            DbProviderFactory provider = SqlClientFactory.Instance;
            var cmd=provider.CreateCommand();
           // cmd.CommandText
        }
    }
}
