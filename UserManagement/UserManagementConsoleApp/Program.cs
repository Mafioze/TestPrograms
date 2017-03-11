using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserControlLibrary;

namespace UserControl
{
    class Program
    {
        static void Main(string[] args)
        {
            IDatabase database = new Database();
            IUserManagement userManager = new UserManagement();
            userManager.Initialize(database);
            IList<IDictionary<string,string>> result = database.ExecuteQuery("select * from Groups_has_Users");

            foreach (var x in result)
                Console.WriteLine(x["idGroup"] + " " + x["idUser"] );
        }
    }
}
