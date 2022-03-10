using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TigerTix.Web.Data
{
    public class TigerTixContent : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
