using Assignment3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Controllers
{
    public class HomeController : Controller
    {
        private MoviesDbContext context { get; set; }
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, MoviesDbContext con)
        {
            _logger = logger;
            context = con;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Movie movie)
        {
            if (ModelState.IsValid)
            { //checking model state
                if (movie.Title == "Independence Day")
                {
                    
                    return View("Confirmation", movie);
                }
                context.Movies.Add(movie);
                context.SaveChanges();
                Temp.AddMovie(movie);
                return View("Confirmation", movie);
            }
            return View();
        }

        [HttpGet]
        public IActionResult Movies()
        {
            return View(context.Movies);
        }

        // delete page

        [HttpPost]
        public IActionResult Delete(int MovieId)
        {
            context.Movies.Remove(context.Movies.Find(MovieId));
            context.SaveChanges();
            return View("Deletion");
        }

        // edit page

        [HttpGet]
        public IActionResult Edit(int MovieId)
        {
            return View("Edit", context.Movies.Find(MovieId));
        }

        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            { //checking model state
                if (movie.Title == "Independence Day")
                {
                    return View("Confirmation", movie);
                }
                context.Movies.Update(movie);
                context.SaveChanges();
                return View("Edited");
            }
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
    }
}
