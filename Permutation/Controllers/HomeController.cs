using Microsoft.AspNetCore.Mvc;
using Permutation.Models;
using System.Diagnostics;

namespace Permutation.Controllers
{
    public class HomeController : Controller
    {
        public static List<string> Words { get; set; }

        public List<string> PermutadedWords = new();

        public List<string> CorrectWords = new();

        public IActionResult Index()
        {
            Words = System.IO.File.ReadAllLines(Dictionaries.Persian).ToList();


            return View();
        }

        [HttpPost]
        public IActionResult Index(PermutationDto permutation)
        {
            if (!string.IsNullOrEmpty(permutation.Text))
            {
                CorrectWords.Clear();
                PermutadedWords.Clear();

                PermutadedWords = PermutationGenerator.GeneratePermutationsWithRepetition(permutation.Text, permutation.Number);
                CorrectWords = Words.Intersect(PermutadedWords).ToList();

                return View(new PermutationDto
                {
                    Text = permutation.Text,
                    Number = permutation.Number,
                    AllCount = PermutadedWords.Count,
                    Words = CorrectWords
                });
            }

            TempData["ErrorMessage"] = Messages.WordRequierd;
            return View(permutation);
        }
    }
}