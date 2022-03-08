using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tigerTix.Controllers
{
    public class AppController : Controller
    {
        [HttpPost("/")]
        public IActionResult Index(object model)
        {
            return View();
        }
    }
}
