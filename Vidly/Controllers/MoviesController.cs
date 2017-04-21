using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movie
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1"},
                new Customer { Name = "Customer 2"}
            };

            var ViewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(ViewModel);
        }

        public ActionResult Details(int Id)
        {
            var Movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == Id);

            if (Movie == null)
                return HttpNotFound();

            return View(Movie);
        }

        public ActionResult Index() //(int? pageIndex, string sortBy)
        {
            //if (!pageIndex.HasValue)
            //    pageIndex = 1;

            //if (string.IsNullOrWhiteSpace(sortBy))
            //    sortBy = "Name";

            var movies = _context.Movies.Include(m => m.Genre).ToList();
            

            return View(movies);

        }

        private IEnumerable<Movie> GetMovies()
        {
            var movies = new List<Movie> { 
                new Movie { Name = "Shrek!" },
                new Movie { Name = "Toy Story" },
                new Movie { Name = "The Jungle Book" }
            };

            return movies;
        }



        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseYear(int year, int month)
        {
            return Content(year + "/" + month);
        }


    }

    
}