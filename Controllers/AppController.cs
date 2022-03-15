using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TigerTix.Web.Data;
using TigerTix.Web.ViewModels;

namespace TigerTix.Web.Controllers
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

        private readonly TigerTixContext _context;
        public AppController(TigerTixContext context)
        {
            _context = context;
        }

        public IActionResult ShowUsers()
        {
            //LINQ Query
            var results = from u in _context.Users select u;
            return View(results.ToList());
        }
    }
}
