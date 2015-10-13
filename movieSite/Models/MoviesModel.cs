using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DATA;
using System.Web.Mvc;
namespace movieSite.Models
{
    public class MoviesModel
    {
        #region properties
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Description { get; set; }
        public string ImdbLink { get; set; }
        public DateTime Viewed { get; set; }
        public List<Movy> MoviesList { get; set; }
        public List<SelectListItem> GenreList { get; set; }
        #endregion
    }
}