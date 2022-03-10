using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TigerTix.Web.Data
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
