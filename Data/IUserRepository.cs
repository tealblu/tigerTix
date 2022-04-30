using System.Collections.Generic;
using TigerTix.Web.Data.Entities;

namespace TigerTix.Web.Data
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        void AddUser(User u);
        void DeleteUser(int id);
        void DeleteAll();
        public void UpdateUser(int userId, string username, string firstname, string lastname);
        public User GetDetails(int id);
        User GetDetailsByUserName(string username);
        bool ValidLogin(string username, string password);
    }
}
