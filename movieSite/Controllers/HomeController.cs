using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DATA.Repositories;
using movieSite.Models;
using PagedList;
using PagedList.Mvc;
using movieSite.Helpers;
namespace movieSite.Controllers
{
    public class HomeController : Controller
    {
        #region actionResult
        // GET: Home
        public ActionResult Index(string search,int? page,string sortby)
        {
            //gets the list of movies in th cache if its empty it gets the movies and store it in cache then uses it.
            var moviesList = CacheHelper.Get<List<DATA.Movy>>("Movies");
            if (moviesList == null) 
            {
                CacheHelper.Add("Movies",MovieRepository.GetMovies());
                moviesList = CacheHelper.Get<List<DATA.Movy>>("Movies");
            }

            //This is for the sort function it stores which sort that should be used 
           ViewBag.sortByName = string.IsNullOrEmpty(sortby) ? "Title desc" : "";
           ViewBag.sortByDate = sortby == "Viewed" ? "Viewed desc" : "Viewed";

           var movies = moviesList.OrderBy(x => x.viewed);

            //this is the function for the search field
            if (search != null)
            {                
                movies = moviesList.Where(x => x.Title.StartsWith(search)).ToList().OrderBy(x => x.Title);                             
            }

            //The actual sorting, using the sortby var to know which sort to use
            switch (sortby)
            {
                case "Title desc":
                    movies = movies.OrderByDescending(x => x.Title);
                    break;
                case "Viewed desc":
                    movies = movies.OrderByDescending(x => x.viewed);
                    break;
                case "Viewed":
                    movies = movies.OrderBy(x => x.viewed);
                    break;
                default:
                    movies = movies.OrderBy(x => x.Title);
                    break; 
             }

            return View(movies.ToPagedList(page ?? 1, 10));
            
        }
        #endregion
    }
}