using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserControlLibrary
{
    public interface IDatabase
    {
        IList<IDictionary<string, string>> ExecuteQuery(string sqlQuery);
    }
}
