using _14Day_EntityFrameWork.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace _14Day_EntityFrameWork.Controllers
{
    public class HomeController : Controller
    {
        private readonly IETDbContext _dbContext;

        public HomeController(IETDbContext Context)
        {
            _dbContext = Context;
        }

        public IActionResult Index()
        {
            var allEmps = _dbContext.emps.ToList();
            return View(allEmps);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AfterCreate(Emp emp)
        {
            _dbContext.emps.Add(emp);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Emp emp = _dbContext.emps.Find(id);
            if (emp != null)
            {
                return View(emp);
            }
            else
            {
                return NotFound(404);
            }
        }

        [HttpPost]
        public IActionResult afterEdit(int id, Emp emp)
        {
            if (ModelState.IsValid)
            {
                Emp em = _dbContext.emps.Find(id);
                em.Name = emp.Name;
                em.Address = emp.Address;
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
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
