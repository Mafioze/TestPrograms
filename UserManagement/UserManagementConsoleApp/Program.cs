using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserControlLibrary;
using System.Data.Entity;

namespace UserControl
{
    class Program
    {
        static void Main(string[] args)
        {
            IDatabase database = new UserControlLibrary.Database();
            IUserManagement userManager = new UserManagement();
            userManager.Initialize(database);
            IList<IDictionary<string, string>> result = database.ExecuteQuery("select * from Groups_has_Users");

            foreach (var x in result)
                Console.WriteLine(x["idGroup"] + " " + x["idUser"]);
            Console.WriteLine();

            UserContext db = new UserContext();

            //User u = new User(11, "Polina");
            //db.Users.Add(u);
            //db.SaveChanges();

            List<User> ulist = db.Users.ToList<User>();
            foreach (var x in ulist)
                Console.WriteLine(x.idUser + " " + x.UserName);

            Console.WriteLine();

            GroupContext gp = new GroupContext();

            //Group g = new Group(4, "Users");
            //gp.Groups.Add(g);
            //gp.SaveChanges();

            List<Group> glist = gp.Groups.ToList<Group>();
            foreach (var x in glist)
                Console.WriteLine(x.idGroup + " " + x.GroupName);
        }
    }
}
