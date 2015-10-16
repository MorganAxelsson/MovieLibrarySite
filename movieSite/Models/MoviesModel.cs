using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DATA;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace movieSite.Models
 
{
    public class MoviesModel
    {
        #region properties
        public int MovieID { get; set; }
        [Required(ErrorMessage = "fill in title")]  
        public string Title { get; set; }

        [Required(ErrorMessage = "fill in genre")]  
        public string Genre { get; set; }        
        public string Director { get; set; }        
        public string Description { get; set; }       
        public string ImdbLink { get; set; }
        public int Rating { get; set; }

        [Required(ErrorMessage = "fill in date")] 
        public DateTime Viewed { get; set; }
        public List<Movy> MoviesList { get; set; }
        public List<SelectListItem> GenreList { get; set; }
        public List<SelectListItem> RatingList { get; set; }
        #endregion
    }
}