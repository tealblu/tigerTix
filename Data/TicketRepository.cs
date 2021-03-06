using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TigerTix.Web.Data.Entities;

namespace TigerTix.Web.Data
{
    public class TicketRepository : ITicketRepository
    {
        // inject tigertix context and create field to enable access
        private readonly TigerTixContext _context;
        public TicketRepository(TigerTixContext context)
        {
            _context = context;
        }

        // methods to create, read, update, and delete data in Tickets table

        //  Returns all Tickets
        public IEnumerable<Ticket> GetAllTickets()
        {
            var tickets = from tick in _context.Tickets select tick;

            return tickets.ToList();
        }

        // Get all Tickets with given eventId
        public IEnumerable<Ticket> GetAllForEvent(int eventId)
        {
            var tickets = from t in _context.Tickets where t.eventID == eventId && t.ownerID == 0 select t;

            return tickets.ToList();
        }

        // Get all Tickets with given userId
        public IEnumerable<Ticket> GetAllForUser(int userId)
        {
            var tickets = from t in _context.Tickets where t.ownerID == userId select t;

            return tickets.ToList();
        }

        // Buy a ticket
        public void BuyTicket(int ticketId, int ownerId)
        {
            var ticket = (from t in _context.Tickets where t.Id == ticketId select t).FirstOrDefault();
            ticket.ownerID = ownerId;

            _context.Update(ticket);
            _context.SaveChanges();
        }

        // Add an Ticket
        public void AddTicket(Ticket tick)
        {
            _context.Add(tick);
            _context.SaveChanges();
        }

        // Delete a Ticket
        public void DeleteTicket(int id)
        {
            var tick = (from t in _context.Tickets where t.Id == id select t).FirstOrDefault();
            _context.Remove(tick);
            _context.SaveChanges();
        }

        // Delete All
        public void DeleteAll()
        {
            var tickets = from t in _context.Tickets select t;
            foreach (var t in tickets)
            {
                _context.Remove(t);
            }
            _context.SaveChanges();
        }

        // Update Ticket
        public void UpdateTicket(int Id, string name, int eventID, int ownerID, float price, int seatSection, int seatNumber)
        {
            Ticket t = new Ticket();
            t.Id = Id;
            t.name = name;
            t.eventID = eventID;
            t.ownerID = ownerID;
            t.price = price;
            t.seatSection = seatSection;
            t.seatNumber = seatNumber;

            _context.Update(t);
            _context.SaveChanges();
        }

        // Get Ticket Details
        public Ticket GetDetails(int id)
        {
            return (from t in _context.Tickets where t.Id == id select t).FirstOrDefault();
        }
    }
}
