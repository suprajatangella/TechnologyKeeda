using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechnologyKeeda.Web.Data;
using TechnologyKeeda.Web.Models;

namespace TechnologyKeeda.Web.Controllers
{
    public class PeopleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PeopleController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var peoples = _context.Peoples.ToList();
            return View(peoples);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(People people)
        {
            _context.Peoples.Add(people);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int Id)
        {
            var people = _context.Peoples.FirstOrDefault(x => x.Id == Id);
            return View(people);
        }
        [HttpPost]
        public IActionResult Edit(People people)
        {
            _context.Peoples.Update(people);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int Id)
        {
            var people = _context.Peoples.FirstOrDefault(x => x.Id == Id);
            return View(people);
        }

        [HttpPost]
        public IActionResult Delete(People people)
        {
            if (people != null)
            {
                _context.Peoples.Remove(people);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int Id)
        {
            var people = _context.Peoples.FirstOrDefault(x => x.Id == Id);
            return View(people);
        }
    }
}
