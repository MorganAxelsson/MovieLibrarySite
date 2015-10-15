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
            model.GenreList = GetGenreList();
            model.Viewed = DateTime.Now.Date;
            return View(model);
        }
        [HttpGet]
        public ActionResult edit(int id)
        {
            var model = new MoviesModel();
            var movie = MovieRepository.GetSpecificMovie(id);
            model.Description = movie.description;
            model.Title = movie.Title;
            model.ImdbLink = movie.ImdbLink;
            model.Director = movie.Director;
            if(movie.viewed != null) model.Viewed = (DateTime)movie.viewed;
            model.MovieID = movie.Id;
            model.GenreList = GetGenreList();
            return View(model);
        }
        public ActionResult Remove(int id)
        {
            MovieRepository.RemoveMovie(id);
            return RedirectToAction("Index", "Home");
        }
        #endregion
        #region post
        [HttpPost]
        public ActionResult Add(MoviesModel model)
        {
            if (!ModelState.IsValid)
            {
                var movieModel = new MoviesModel();
                movieModel.GenreList = GetGenreList();
                movieModel.Viewed = DateTime.Now.Date;
                return View(movieModel);
            }
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
        [HttpPost]
        public ActionResult Edit(MoviesModel model, int Id)
        {
            if (!ModelState.IsValid)
            {
                var movieModel = new MoviesModel();
                movieModel.GenreList = GetGenreList();
                movieModel.Viewed = model.Viewed;
                movieModel.MovieID = Id;
                return View(movieModel);
            }

            var movie = new Movy();
            movie.Title = model.Title;
            movie.ImdbLink = model.ImdbLink;
            movie.description = model.Description;
            movie.Director = model.Director;
            movie.Genre = model.Genre;
            movie.viewed = model.Viewed;
            MovieRepository.UpdateMovie(movie, Id);
            return RedirectToAction("Index", "Home");
        }
        #endregion
        #endregion
        #region private methods
        private List<SelectListItem> GetGenreList()
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
        #endregion
    }
}