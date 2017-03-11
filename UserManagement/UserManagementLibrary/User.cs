using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserControlLibrary
{
    public class User
    {
        [Key]
        public int idUser { get; set; }
        public string UserName { get; set; }

        public User()
        {
            
        }
        public User(int UserID, string Name)
        {
            idUser = UserID;
            UserName = Name;
        }
    }

    public class UserContext : DbContext
    {
        public UserContext() : base("MyConnection") { }

        public DbSet<User> Users { get; set; }
    }

}
