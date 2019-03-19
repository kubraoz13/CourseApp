using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseApp.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CourseApp.Controllers
{
    public class HomeController : Controller
    {
        private DataContext context;
        public HomeController(DataContext _context) //ctor yazıp taba bas
        {
            context = _context;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            //CourseApp.Models.Request model = new Models.Request();
            //model.Name = "Kübra Öz";
            //model.Email = "ozkbraa@gmail.com";
            //model.Phone = "05356455225";
            //model.Message = "S.A";
            return View();
        }
        [HttpGet]
        public IActionResult AddRequest() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddRequest(Request model)
        {
            context.Requests.Add(model);
            context.SaveChanges();
            return View("Thanks",model);
        }
        [HttpGet]
        public IActionResult List()
        {
            return View(context.Requests);
        }
    }
}
