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
        public User GetDetails(int id);
    }
}