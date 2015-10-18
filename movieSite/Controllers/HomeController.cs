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
            var moviesList = CacheHelper.Get<List<DATA.Movy>>("Movies");
            if (moviesList == null) 
            {
                CacheHelper.Add("Movies",MovieRepository.GetMovies());
                moviesList = CacheHelper.Get<List<DATA.Movy>>("Movies");
            }
            //ViewBag.sortByName = string.IsNullOrEmpty(sortby) ? "Name desc" : "";
            //ViewBag.sortByDate == "Date" ? "Date desc" : "Date";

            
            if (search != null)
            {
                
                var movies = moviesList.Where(x => x.Title.StartsWith(search)).ToList().OrderBy(x => x.Title);

                return View(movies.ToPagedList(page ?? 1, 10));
            }
            else
            { 
                 moviesList.OrderBy(x=>x.Title);
                 return View(moviesList.ToPagedList(page ?? 1, 10));
            }

            //switch (sortby)
            //{
            //    case "Name desc":
                    



            //}
            
        }
        #endregion
    }
}