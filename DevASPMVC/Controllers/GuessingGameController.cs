using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevASPMVC.Controllers
{
    public class GuessingGameController : Controller
    {
        readonly Random random = new Random();
        private const string SessionKeyNumber = "_Number";
        private const string SessionKeyGuesses = "_Guesses";
        
        // GET
        public IActionResult Game()
        {
            ResetSessions();

            return View();
        }
        
        [HttpPost]
        public IActionResult Game(int? guess)
        {
            if (guess == null)
            {
                ViewBag.Message = "Guess invalid";
                return View();
            }
            
            int? numberToGuess = HttpContext.Session.GetInt32(SessionKeyNumber);
            int? guesses = HttpContext.Session.GetInt32(SessionKeyGuesses);
            guesses++;

            if (guesses != null) HttpContext.Session.SetInt32(SessionKeyGuesses, (int) guesses);
            else HttpContext.Session.SetInt32(SessionKeyGuesses, 1); // Set to 1 and not 0 because we just made a guess
            
            if (guess == numberToGuess)
            {
                ViewBag.Message = $"You guessed the number in {guesses} tries! A new number has been generated.";
                ResetSessions();
            }
            else if (guess > numberToGuess)
            {
                ViewBag.Message = $"Your guess is too high. You have guessed {guesses} times";
            }
            else
            {
                ViewBag.Message = $"Your guess it too low. You have guessed {guesses} times";
            }

            return View();
        }

        private void ResetSessions()
        {
            HttpContext.Session.SetInt32(SessionKeyNumber, random.Next(1, 101));
            HttpContext.Session.SetInt32(SessionKeyGuesses, 0);
        }

    }
}