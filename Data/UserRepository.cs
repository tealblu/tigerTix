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
        // save a user
        public void SaveUser(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        // returns all users
        public IEnumerable<User> GetAllUsers()
        {
            var users = from u in _context.Users select u;

            return users.ToList();
        }

        // return a single user by ID
        public User GetUsersByID(int userID)
        {
            var user = (from u in _context.Users where u.Id == userID select u).FirstOrDefault();

            return user;
        }

        // Update a user
        public void UpdateUser(User user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }

        // Delete a user
        public void DeleteUser(User user)
        {
            _context.Remove(user);
            _context.SaveChanges();
        }

        // Save All
        public bool SaveAll()
        {
            // Save changes returns the row of numbers affected
            return _context.SaveChanges() > 0;
        }
    }
}
