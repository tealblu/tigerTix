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
    public class EventsController : Controller
    {
        private readonly IEventRepository _eventRepository;
        public EventsController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public IActionResult Index()
        {
            //LINQ Query
            var results = from e in _eventRepository.GetAllEvents() select e;
            return View(results.ToList());
        }

        public IActionResult Submit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Submit(Event e) 
        {
            _eventRepository.SaveEvent(e);
            _eventRepository.SaveAll();

            return View();
        }
    }
}
