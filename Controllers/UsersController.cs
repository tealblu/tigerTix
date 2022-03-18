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

        [HttpPost]
        public IActionResult Submit(User user)
        {
            _userRepository.SaveUser(user);
            _userRepository.SaveAll();

            return View();
        }
    }
}
