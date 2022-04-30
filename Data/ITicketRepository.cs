using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TigerTix.Web.Data.Entities;

namespace TigerTix.Web.Data
{
    public interface ITicketRepository
    {
        IEnumerable<Ticket> GetAllTickets();
        IEnumerable<Ticket> GetAllForEvent(int eventId);
        IEnumerable<Ticket> GetAllForUser(int userId);
        void BuyTicket(int ownerId, int ticketId);
        void AddTicket(Ticket tick);
        void DeleteTicket(int id);
        void DeleteAll();
        public void UpdateTicket(int Id, string name, int eventID, int ownerID, float price, int seatSection, int seatNumber);
        Ticket GetDetails(int id);
    }
}
