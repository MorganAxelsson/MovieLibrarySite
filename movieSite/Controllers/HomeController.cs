using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DATA.Repositories;
using movieSite.Models;
using PagedList;
using PagedList.Mvc;
namespace movieSite.Controllers
{
    public class HomeController : Controller
    {
        #region actionResult
        // GET: Home
        public ActionResult Index(string search,int? page)
        {
            if (search != null)
            {
                var movies = MovieRepository.SearchForMovies(search).OrderBy(x => x.Title);
                return View(movies.ToPagedList(page ?? 1, 10));
            }
            else
            { 
                 var movies = MovieRepository.GetMovies().OrderBy(x=>x.Title);
                 return View(movies.ToPagedList(page ?? 1, 10));
            }
            
        }
        #endregion
    }
}