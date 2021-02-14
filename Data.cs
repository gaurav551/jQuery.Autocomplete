using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JQuery.AutoComplete.Models;

namespace JQuery.AutoComplete.Controllers
{
    public class HomeController : Controller
    {
        public List<Doctor> Doctors { get; set; }
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            Doctors = new List<Doctor>(){
                new Doctor(){Id=1, Name="gaurav", Image = "unnamed(1).png"},
                 new Doctor(){Id=2, Name="gaurav1", Image = "unnamed(2).png"},
                  new Doctor(){Id=3, Name="gaurav2", Image = "unnamed(3).png"},
                   new Doctor(){Id=4, Name="gaurav3", Image = "unnamed.png"},
                    new Doctor(){Id=5, Name="gaurav4", Image = "unnamed(1).png"},
            };
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
       [HttpGet]
    public IActionResult AutoComplete(string prefix)
    {
               var customers = (from customer in Doctors
                         where 
                         customer.Name.Replace("'", "").Replace("\"", "").Replace("#", "").Replace("/", "").Replace("-", "").Contains(prefix)
                         select new
                         {
                             customer.Name,
                             customer.Image
                         }).ToList();
                     
   
    

 
        return Json(customers);
    }
    }
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
}
