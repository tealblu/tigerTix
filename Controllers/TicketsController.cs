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
    public class TicketsController : Controller
    {
        private readonly ITicketRepository _ticketRepository;
        public TicketsController(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public IActionResult Index()
        {
            var results = from t in _ticketRepository.GetAllTickets() select t;
            return View(results);
        }

        public IActionResult Submit()
        {
            return View();
        }

        // HTTP Request Handeling //

        [HttpGet("/tickets")]
        public IActionResult GetTickets(int id)
        {
            if (id != 0)
            {
                var t = _ticketRepository.GetDetails(id);
                return Ok(t);
            }
            else
            {
                var results = from t in _ticketRepository.GetAllTickets() select t;
                return Ok(results.ToList());
            }
        }

        [HttpPost("/tickets")]
        public IActionResult Submit(Ticket t)
        {
            _ticketRepository.AddTicket(t);

            return View();
        }

        [HttpDelete("/tickets/{ticketId}:id")]
        public IActionResult Delete(int ticketId)
        {
            _ticketRepository.DeleteTicket(ticketId);

            return View("submit");
        }

        [HttpPut("/tickets/{ticketId}:id")]
        public IActionResult UpdateTicket(int ticketId, string name, int eventId, int ownerId, float price, int seatSection, int seatNumber)
        {
            _ticketRepository.UpdateTicket(ticketId, name, eventId, ownerId, price, seatSection, seatNumber);

            return View("submit");
        }

        [HttpDelete("/tickets/DeleteAll")]
        public IActionResult DeleteAll()
        {
            _ticketRepository.DeleteAll();

            return View("submit");
        }
    }
}
