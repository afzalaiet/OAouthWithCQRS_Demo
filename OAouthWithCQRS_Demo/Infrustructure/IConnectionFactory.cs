using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeremonyBazar.Infrustructure
{
    public interface IConnectionFactory : IDisposable
    {
        /// <summary>
        /// Create and Returns Open connection.
        /// </summary>
        SqlConnection GetConnection { get; }
    }
}
