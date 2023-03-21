using System;
using System.Collections.Generic;
using System.Data.Entity; // test2.3
using System.Linq; // test2.3
using System.Web.Mvc;
using Exercise1.Models;
using Exercise1.ViewModels;

namespace Exercise1.Controllers
{
    public class MoviesController : Controller
    {

        // test2.3
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            // var movies = GetMovies();
            // test2.3
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            return View(movies);
        }

        // add with test2.3 the Details -> the error gives back with the single movie will generate about this absence
        public ActionResult Details(int Id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == Id);
            // we add this so VieewResult gives error.
            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        /* private object GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "Sherk" },
                new Movie { Id = 2, Name = "Wall-e"}
            };
        }
        */

        // after test2.3 this isn't used
        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "Sherk" },
                new Movie { Id = 1, Name = "Wall-e" }
            };
        }

        // test3 <<
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();

            var ViewModel = new MovieFormViewModels
            {
                Genres = genres
            };

            return View("MovieForm", ViewModel);
        }

        public ActionResult Create(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.DateAdded = movie.DateAdded;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NumberInStock = movie.NumberInStock;

            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");

        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModels
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }
        // >>
    }

    // Old:
    /*
     * public class MoviesController : Controller
    {
        //Movie
         * public ActionResult Index(){
         *  return View();
         * }
         * 
         * Ampliata con la classe Random

    // 1
    // GET: /Movie/Random
    public ActionResult Random()
    {
        // define the value of Movie, often Data is from a DB
        var movie = new Movie() { Name = "Sherk!" };
        /* 
         * var movies = new List<Movie>
         * {
         * new Movie { Name = "Sherk" },
         * new Movie {Name = "Wall-e"}
         * };
         * First try for ex1 but it's not correct, Random needs movie as a value, not a list. 

        1 impl
        // return it to the View
        return View();
    */
    /*
        var customers = new List<Customer>
            {
                /* new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" } 
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" } ,
            };

        var viewModel = new RandomMovieViewModel
        {
            Movie = movie,
            Customers = customers
        };

        //4 impl ep14 cap2
        ViewData["Movie"] = movie;
        ViewBag.Movie = movie; // it is used to can change viewData there without touch the View Random.cshtml
        return View();
        // tolto con il 4 impl : return View(movie);


        // 5 impl non funzionante da corso lo finisce così
        // var viewResult = new ViewResult();
        /* viewResult.ViewData.Model = viewModel; -> Avrebbe senso fatta così, 
         * quindi aggiungendo la parte del implemento successivo var viewModel e metterglielo all'interno del viewResult
         * ma è un passaggio in più senza un reale senso
        // return viewResult; 

        // 5 return View(movie);
        return View(viewModel);
    }

    public ActionResult Edit(int id)
    {
        return Content("id = " + id);
    }

    // movies
    public ActionResult Index(int? pageIndex, string sortBy)
    {
        if (!pageIndex.HasValue)
        {
            pageIndex = 1;
        }
        if (String.IsNullOrWhiteSpace(sortBy))
        {
            sortBy = "Name";
        }

        return Content(string.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
    }

    // 3 implemento cap13 it is the new Custom Route, il \d non dovrebbe essere così, messo la soluzione su Obsidian
    //[Route("movies/released/{year}/{month:regex(\\d{4}):range(1, 12)}")]
    [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{4}):range(1, 12)}")]
    // 2 implemento ep12 
    public ActionResult ByReleaseDate(int year, int month)
    {
        return Content(year + "/" + month);
    }
}
*/
}