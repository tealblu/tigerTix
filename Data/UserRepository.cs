using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TigerTix.Web.Data.Entities;

namespace TigerTix.Web.Data
{
    public class UserRepository : IUserRepository
    {
        // inject tigertix context and create field to enable access
        private readonly TigerTixContext _context;
        public UserRepository(TigerTixContext context)
        {
            _context = context;
        }

        // methods to create, read, update, and delete data in Users table

        //  Returns all users
        public IEnumerable<User> GetAllUsers()
        {
            var users = from u in _context.Users select u;

            return users.ToList();
        }

        // Add an user
        public void AddUser(User u)
        {
            _context.Add(u);
            _context.SaveChanges();
        }

        // Delete a user
        public void DeleteUser(int id)
        {
            var ev = (from u in _context.Users where u.Id == id select u).FirstOrDefault();
            _context.Remove(ev);
            _context.SaveChanges();
        }

        // Delete All
        public void DeleteAll()
        {
            var users = from u in _context.Users select u;
            foreach (var u in users)
            {
                _context.Remove(u);
            }
            _context.SaveChanges();
        }

        // Update User
        public void UpdateUser(int userId, string username, string firstname, string lastname)
        {
            User u = new User();
            u.Id = userId;
            u.UserName = username;
            u.FirstName = firstname;
            u.LastName = lastname;

            _context.Update(u);
            _context.SaveChanges();
        }

        // Get User Details
        public User GetDetails(int id)
        {
            return (from u in _context.Users where u.Id == id select u).FirstOrDefault();
        }
    }
}
