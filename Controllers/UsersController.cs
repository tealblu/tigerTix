using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TigerTix.Web.Data;
using TigerTix.Web.Data.Entities;
using TigerTix.Web.ViewModels;


namespace TigerTix.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            //LINQ Query
            var results = from u in _userRepository.GetAllUsers() select u;
            return View(results.ToList());
        }

        public IActionResult Submit()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        // HTTP Request Handeling //

        [HttpGet("/users")]
        public IActionResult GetUsers(int id)
        {
            if (id != 0)
            {
                var u = _userRepository.GetDetails(id);
                return Ok(u);
            }
            else
            {
                var results = from u in _userRepository.GetAllUsers() select u;
                return Ok(results.ToList());
            }
        }

        [HttpGet("/users/validLogin")]
        public IActionResult ValidLogin(string username, string password)
        {
            var valid = _userRepository.ValidLogin(username, password);
            if (valid)
            {
                var user = _userRepository.GetDetailsByUserName(username);
                return Ok(user);
            }
            else
            {
                return StatusCode(401);
            }
        }

        [HttpPost("/users")]
        public IActionResult Submit(User u)
        {
            _userRepository.AddUser(u);

            return View();
        }

        [HttpDelete("/users/{userId}:id")]
        public IActionResult Delete(int userId)
        {
            _userRepository.DeleteUser(userId);

            return View("submit");
        }

        [HttpPut("/users/{userId}:id")]
        public IActionResult UpdateUser(int userId, string username, string firstname, string lastname)
        {
            _userRepository.UpdateUser(userId, username, firstname, lastname);

            return View("submit");
        }

        [HttpDelete("/users/DeleteAll")]
        public IActionResult DeleteAll()
        {
            _userRepository.DeleteAll();

            return View("submit");
        }
    }
}
