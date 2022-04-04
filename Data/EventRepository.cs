using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TigerTix.Web.Data.Entities;

namespace TigerTix.Web.Data
{
    public class EventRepository : IEventRepository
    {
        // inject tigertix context and create field to enable access
        private readonly TigerTixContext _context;
        public EventRepository(TigerTixContext context)
        {
            _context = context;
        }

        // methods to create, read, update, and delete data in Events table

        //  Returns all events
        public IEnumerable<Event> GetAllEvents()
        {
            var events = from ev in _context.Events select ev;

            return events.ToList();
        }

        // Add an event
        public void AddEvent(Event ev)
        {
            _context.Add(ev);
            _context.SaveChanges();
        }

        // Delete a event
        public void DeleteEvent(int id)
        {
            var ev = (from e in _context.Events where e.Id == id select e).FirstOrDefault();
            _context.Remove(ev);
            _context.SaveChanges();
        }

        // Delete All
        public void DeleteAll()
        {
            var events = from ev in _context.Events select ev;
            foreach (var e in events)
            {
                _context.Remove(e);
            }
            _context.SaveChanges();
        }

        // Update Event
        public void UpdateEvent(int eventId, string title, string desc, string date, string venue, string owner)
        {
            Event ev = new Event();
            ev.Id = eventId;
            ev.title = title;
            ev.desc = desc;
            ev.date = date;
            ev.venue = venue;
            ev.owner = owner;

            _context.Update(ev);
            _context.SaveChanges();
        }

        // Get Event Details
        public Event GetDetails(int id)
        {
            return (from e in _context.Events where e.Id == id select e).FirstOrDefault();
        }
    }
}
