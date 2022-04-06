using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TigerTix.Web.Data.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int eventID { get; set; }
        public int ownerID { get; set; }
        public float price { get; set; }
        public int seatSection { get; set; }
        public int seatNumber { get; set; }
    }
}
