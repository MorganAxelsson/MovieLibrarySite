using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using movieSite.Models;
using DATA;
using DATA.Repositories;

namespace movieSite.Controllers
{
    public class MovieController : Controller
    {
        #region actionResult
        #region get
        // GET: Movie
        [HttpGet]
        public ActionResult Add()
        {
            var model = new MoviesModel();
            model.GenreList = GetGenre();
            model.Viewed = DateTime.Now.Date;
            return View(model);
        }
        #endregion
        #region post
        [HttpPost]
        public ActionResult Add(MoviesModel model)
        {
            var movie = new Movy();
            movie.Title = model.Title;
            movie.ImdbLink = model.ImdbLink;
            movie.description = model.Description;
            movie.Director = model.Director;
            movie.Genre = model.Genre;
            movie.viewed = model.Viewed;
            MovieRepository.AddMovie(movie);
            return RedirectToAction("Index","Home");
        }
        #endregion
        #endregion

        private List<SelectListItem> GetGenre()
        {
            var genreList = new List<SelectListItem>();
            var data = new[]{
                 new SelectListItem{ Value="Action",Text="Action"},
                 new SelectListItem{ Value="Horror",Text="Horror"},
                 new SelectListItem{ Value="Drama",Text="Drama"},
                 new SelectListItem{ Value="Science fiction",Text="Science fiction"},
                 new SelectListItem{ Value="Comedy",Text="Comedy"},
                 new SelectListItem{ Value="Fantasy",Text="Fantasy"},
                 new SelectListItem{ Value="Crime",Text="Crime"},
                 new SelectListItem{ Value="Adventure",Text="Adventure"},
                 new SelectListItem{ Value="Thriller",Text="Thriller"},
                 new SelectListItem{ Value="Romance",Text="Romance"},
             };
            genreList = data.ToList();
            return genreList;
        }
    }
}