using DevASPMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevASPMVC.Controllers
{
    public class DoctorController : Controller
    {
        // GET
        public IActionResult FeverCheck()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult FeverCheck(float temperature)
        {
            if (Utilities.CheckFever(temperature))
            {
                ViewBag.Message = "You have a fever!";
            }
            else if (Utilities.CheckHypothermia(temperature))
            {
                ViewBag.Message = "You have hypothermia!";
            }
            else
            {
                ViewBag.Message = "You do not have a fever or hypothermia!";
            }
            
            return View();
        }
    }
}