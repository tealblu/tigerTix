using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TigerTix.Web.Data
{
    public class UserRepository
    {
        // inject tigertix context and create field to enable access
        private readonly TigerTixContext _context;
        public UserRepository(TigerTixContext context)
        {
            _context = context;
        }

        // methods to create, read, update, and delete data in Users table
        
    }
}
