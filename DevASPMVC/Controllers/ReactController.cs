using DevASPMVC.Models;
using Microsoft.AspNetCore.Mvc;

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
            Person person = _context.People.Find(id);

            return Json(person);
        }
    }
}