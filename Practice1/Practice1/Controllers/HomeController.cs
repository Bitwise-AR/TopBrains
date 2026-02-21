using Microsoft.AspNetCore.Mvc;
using Practice1.Models;
using System.Diagnostics;

namespace Practice1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Fetch()
        {
            var employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "Ayush", Department = "IT", Salary = 60000 },
                new Employee { Id = 2, Name = "Sparsh", Department = "IT", Salary = 55000 },
                new Employee { Id = 3, Name = "Anushka", Department = "Finance", Salary = 35000 },
                new Employee { Id = 4, Name = "Aakarsh", Department = "IT", Salary = 30000 },
                new Employee { Id = 5, Name = "Shikha", Department = "IT", Salary = 70000 }
            };

            var result = employees
                .Where(e => e.Salary > 50000)
                .GroupBy(e => e.Department)
                .ToDictionary(g => g.Key, g => g.ToList());

            return View(result);
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
    }
}
