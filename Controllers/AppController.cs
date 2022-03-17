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
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("/")]
        public IActionResult Index(Event ev) 
        {
            _eventRepository.SaveEvent(ev);
            _eventRepository.SaveAll();

            return View();
        }

        [HttpPost("/Users")]
        public IActionResult Users(User user)
        {
            _userRepository.SaveUser(user);
            _userRepository.SaveAll();

            return View();
        }

        public IActionResult Users()
        {
            return View();
        }

        public IActionResult ShowUsers()
        {
            //LINQ Query
            var results = from u in _userRepository.GetAllUsers() select u;
            return View(results.ToList());
        }

        public IActionResult ShowEvents()
        {
            //LINQ Query
            var results = from u in _eventRepository.GetAllEvents() select u;
            return View(results.ToList());
        }

        private readonly IEventRepository _eventRepository;
        private readonly IUserRepository _userRepository;
        public AppController(IEventRepository eventRepository, IUserRepository userRepository)
        {
            _eventRepository = eventRepository;
            _userRepository = userRepository;
        }
        
    }
}
