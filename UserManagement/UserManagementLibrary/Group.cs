using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserControlLibrary
{
    public class Group
    {
        [Key]
        public int idGroup { get; set; }
        public string GroupName { get; set; }

        public Group()
        {

        }
        public Group(int GroupID, string Name)
        {
            idGroup = GroupID;
            GroupName = Name;
        }
    }

    public class GroupContext : DbContext
    {
        public GroupContext() : base("MyConnection") { }

        public DbSet<Group> Groups { get; set; }
    }
}
