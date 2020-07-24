using MvcTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTest.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies

        //public ActionResult Random()
        //{
        //    var movie = new Models.Movie() { Name = "Sherek" };

        //    var customers = new List<Models.Custumer>
        //    {
        //    new  Models.Custumer{Name = "Andi" },
        //    new  Models.Custumer{Name = "Negin" },
        //    new  Models.Custumer{Name = "Niloo" },
        //    new  Models.Custumer{Name = "Naz" },
        //    new  Models.Custumer{Name = "Elena" },
        //    new  Models.Custumer{Name = "Shadi" }
        //     };
        //    var viewModel = new ViewModels.RandomMovieModel()
        //    {
        //        Movie = movie,
        //        Custumer = customers
        //    };

        //    return View(viewModel);
        //}
       // [Route("Movies/Index")]
        public ViewResult Index()
        {
            var movies = GetMovies();

            return View(movies);
        }

        private IEnumerable<Models.Movie> GetMovies()
        {
            DataAccess DB = new DataAccess();
            return DB.GetMovies();

            //return new List<Movie>
            //{
            //    new Movie { Id = 1, Name = "Shrek" },
            //    new Movie { Id = 2, Name = "Wall-e" }
            //};
        }
     //  [Route("Movies/Index/Movieoparation")]
       
        public ActionResult Movieoparation()
        {
            return View();   
        }
         [Route("Movies/Create")]
        [HttpPost]
        public ActionResult Create(Models.Movie Movie) 
        {
            DataAccess DA = new DataAccess();
           int RecordNo= DA.AddNewMovie(Movie.Name);
            return RedirectToAction("Index");
        }

    }
}