using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
            var results = from e in _eventRepository.GetAllEvents() select e;
            return View(results);
        }

        public IActionResult Submit()
        {
            return View();
        }

        // HTTP Request Handeling //

        [HttpGet("/events")]
        public IActionResult GetEvents(int id)
        {
            if (id != 0)
            {
                var ev = _eventRepository.GetDetails(id);
                return Ok(ev);
            } else
            {
                var results = from e in _eventRepository.GetAllEvents() select e;
                return Ok(results.ToList());
            }
        }

        [HttpPost("/events")]
        public IActionResult Submit(Event e)
        {
            _eventRepository.AddEvent(e);

            return View();
        }

        [HttpDelete("/events/{eventId}:id")]
        public IActionResult Delete(int eventId)
        {
            _eventRepository.DeleteEvent(eventId);

            return View("submit");
        }

        [HttpPut("/events/{eventId}:id")]
        public IActionResult UpdateEvent(int eventId, string title, string desc, string date, string venue, string owner)
        {
            _eventRepository.UpdateEvent(eventId, title, desc, date, venue, owner);

            return View("submit");
        }

        [HttpDelete("/events/DeleteAll")]
        public IActionResult DeleteAll()
        {
            _eventRepository.DeleteAll();

            return View("submit");
        }
    }
}
