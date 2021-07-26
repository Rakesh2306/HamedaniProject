using HamedaniProject.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HamedaniProject.Controllers
{
    public class MoviesController : Controller
    {
        private HamedaniProjectNewEntities _context;
        public MoviesController()
        {
            _context = new HamedaniProjectNewEntities();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movies
        public ActionResult Index()
        {
            var getAllMovies = _context.MoviesTables.ToList();

            MoviesViewModel moviesViewModel = new MoviesViewModel();

            moviesViewModel.MoviesTable = getAllMovies;

            return View(moviesViewModel);
        }

        public ActionResult MovieDetails(int Id)
        {
            var getMovieDetails = _context.MoviesTables.SingleOrDefault(e => e.Id == Id);


            return View("AddMovies",getMovieDetails);

        }



        public ActionResult AddMovies()
        {
            var movies = new MoviesTable();

            return View(movies);
        }


        [HttpPost]
        public ActionResult AddMoviesToDb(MoviesTable movies)

        {
            if (!ModelState.IsValid)
            {
                var Movies = new MoviesTable();

                return View("AddMovies", Movies);
            }
            else
            {
                var element = _context.MoviesTables.Any(c => c.Id == movies.Id);

                if (element)
                {
                    var moviesInDb = _context.MoviesTables.Single(c => c.Id == movies.Id);
                    moviesInDb.Name = movies.Name;
                    moviesInDb.ReleaseDate = movies.ReleaseDate;
                    moviesInDb.Genre = movies.Genre;
                    moviesInDb.AvailableStock = movies.AvailableStock;

                    _context.SaveChanges();
                    return RedirectToAction("Index", "Movies");
                }
                else
                {
                    _context.MoviesTables.Add(movies);
                    _context.SaveChanges();
                    return RedirectToAction("Index", "Movies");

                }


            }



        }



    }
}