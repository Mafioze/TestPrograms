using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserControlLibrary
{
    public class UserManagement : IUserManagement
    {

        private static IDatabase _database;

        public void AddUserToGroup(string groupName, string userName)
        {
            _database.ExecuteQuery("INSERT INTO Groups_Has_Users(idGroup, idUser) VALUES((select idGroup from Groups where GroupName='" + groupName + "'), (select idUser from Users where UserName='" + userName + "'));");
        }

        public string CreateGroup(string groupName)
        {
            _database.ExecuteQuery("INSERT INTO Groups(GroupName) VALUES('"+ groupName +"');");
            return groupName;
        }

        public string CreateUser(string userName)
        {
            _database.ExecuteQuery("INSERT INTO Users(UserName) VALUES('" + userName + "');");
            return userName;
        }

        public void DeleteGroup(string groupName)
        {
            _database.ExecuteQuery("DELETE FROM Groups WHERE GroupName=" + groupName);
        }

        public void DeleteUser(string userName)
        {
            _database.ExecuteQuery("DELETE FROM Users WHERE UserName=" + userName);
        }

        public void DeleteUserFromGroup(string groupName, string userName)
        {
            _database.ExecuteQuery("DELETE FROM Groups_Has_Users WHERE idGroup = (select idGroup from Groups where GroupName = '" + groupName + "') AND idUser = (select idUser from Users where UserName='" + userName + "'));");
        }

        public void Initialize(IDatabase database)
        {
            _database = database;
        }
    }
}
