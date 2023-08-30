using Microsoft.AspNetCore.Mvc;
using Permutation.Models;

namespace Permutation.Controllers
{
    public class HomeController : Controller
    {
        public static List<string> Words { get; set; }
        public List<string> PermutadedWords = new();
        public List<string> CorrectWords = new();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(PermutationDto permutation)
        {
            if (!string.IsNullOrEmpty(permutation.Text))
            {
                Words = System.IO.File.ReadAllLines(permutation.IsPersian ? Dictionaries.Persian : Dictionaries.English).ToList();

                CorrectWords.Clear();
                PermutadedWords.Clear();

                PermutadedWords = PermutationGenerator.GeneratePermutationsWithRepetition(permutation.Text.ToLower(), permutation.Number);
                CorrectWords = Words.Intersect(PermutadedWords).ToList();

                return View(new PermutationDto
                {
                    Text = permutation.Text,
                    Number = permutation.Number,
                    AllCount = PermutadedWords.Count,
                    IsPersian = permutation.IsPersian,
                    Words = CorrectWords
                });
            }

            TempData["ErrorMessage"] = Messages.WordRequired;
            return View(permutation);
        }

        [HttpGet]
        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
    }
}