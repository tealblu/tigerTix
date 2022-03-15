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

        private readonly IConfiguration _config;

        public TigerTixContext (IConfiguration config)
        {
            _config = config;
        }

        proteted override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_config["ConnectionStrings:DefaultConnection"]);
        }
    }
}
