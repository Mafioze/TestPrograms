using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserControlLibrary
{
    public interface IUserManagement
    {
        string CreateUser(string FIO);
        void DeleteUser(string FIO);
        string CreateGroup(string groupName);
        void DeleteGroup(string groupName);
        void AddUserToGroup(string groupName, string FIO);
        void DeleteUserFromGroup(string groupName, string FIO);
        void Initialize(IDatabase database);
    }
}
