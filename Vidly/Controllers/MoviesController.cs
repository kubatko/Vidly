using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
    
        [Route("movies/release/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult Random(int? id)
        {
            Movie movie = new Movie() { Name = "Shrek !" };
            //ViewData["Movie"] = movie;

            var customers = new List<Customer>
            {
                new Customer() { Name = "Customer 1"},
                new Customer() { Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

       
    }
}