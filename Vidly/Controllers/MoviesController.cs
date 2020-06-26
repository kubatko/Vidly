using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private VidlyDbContext _dbContext = new VidlyDbContext();

        public ActionResult Index()
        {
            return View(_dbContext.Movies.Include(m => m.Genre).ToList());
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = _dbContext.Movies.Include(m => m.Genre).Where(m => m.Id == id).FirstOrDefault();
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        public ActionResult New()
        {
            MovieFormViewModel viewModel = new MovieFormViewModel()
            {
                Genres = _dbContext.MovieGenres,
                Movie = new Movie()
                {
                    ReleaseDate = new DateTime(),
                    NumberInStock = 0
                },
            };

            ViewBag.Title = "New Movie";

            return View("MovieForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel()
                {
                    Movie = movie,
                    Genres = _dbContext.MovieGenres
                };



                return View("MovieForm", viewModel);
            }


            if (movie.Id == 0)
            {
                _dbContext.Movies.Add(movie);
            }
            else
            {
                var dbMovie = _dbContext.Movies.SingleOrDefault(m => m.Id == movie.Id);

                dbMovie.Name = movie.Name;
                dbMovie.NumberInStock = movie.NumberInStock;
                dbMovie.ReleaseDate = movie.ReleaseDate;
                dbMovie.GenreId = movie.GenreId;
            }


            _dbContext.SaveChanges();
            
            
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var movie = _dbContext.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel()
            {
                Movie = movie,
                Genres = _dbContext.MovieGenres.ToList()
            };

            ViewBag.Title = "Edit Movie";

            return View("MovieForm", viewModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
