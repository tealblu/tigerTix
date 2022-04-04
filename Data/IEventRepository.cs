using System.Collections.Generic;
using TigerTix.Web.Data.Entities;

namespace TigerTix.Web.Data
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAllEvents();
        void AddEvent(Event ev);
        void DeleteEvent(int id);
        void DeleteAll();
        public void UpdateEvent(int eventId, string title, string desc, string date, string venue, string owner);
        Event GetDetails(int id);
    }
}