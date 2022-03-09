using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TigerTix.Web.ViewModels
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("/")]
        public IActionResult Index(IndexViewModel model)
        {
            return View();
        }
    }
}
