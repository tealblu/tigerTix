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
        Event GetDetails(int id);
    }
}