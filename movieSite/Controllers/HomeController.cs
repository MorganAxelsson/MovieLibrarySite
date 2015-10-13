using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DATA.Repositories;
using movieSite.Models;
namespace movieSite.Controllers
{
    public class HomeController : Controller
    {
        #region actionResult
        // GET: Home
        public ActionResult Index()
        {
            var model = new MoviesModel();
            model.MoviesList = MovieRepository.GetMovies();
            return View(model);
        }
        #endregion
    }
}