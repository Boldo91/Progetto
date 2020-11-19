using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoCinema
{
    public abstract class SqlProvider
    {
        protected string _connectionString;

        public SqlProvider(string conn)
        {
            _connectionString = conn;

        }
    }
}
