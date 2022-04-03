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

        // HTTP Request Handeling //
        [HttpGet("/users")]
        public IActionResult GetEvents(int id)
        {
            if (id != 0)
            {
                var ev = _userRepository.GetDetails(id);
                return Ok(ev);
            }
            else
            {
                var results = from u in _userRepository.GetAllUsers() select u;
                return Ok(results.ToList());
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


        [HttpDelete("/users/DeleteAll")]
        public IActionResult DeleteAll()
        {
            _userRepository.DeleteAll();

            return View("submit");
        }
    }
}
