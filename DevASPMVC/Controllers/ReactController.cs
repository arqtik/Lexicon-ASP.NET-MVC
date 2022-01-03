using System.Linq;
using DevASPMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevASPMVC.Controllers
{
    public class ReactController : Controller
    {
        private readonly AppDbContext _context;

        public ReactController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        
        // GET
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult People()
        {
            return Json(_context.People);
        }

        public IActionResult Person(int id)
        {
            Person person = _context.People
                .Where(p => p.ID == id)
                .Include(p => p.City)
                .Include(p => p.Languages)
                .FirstOrDefault();

            return Json(person);
        }
    }
}