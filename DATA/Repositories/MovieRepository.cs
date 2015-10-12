using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Repositories
{
    public static class MovieRepository
    {
        #region Public methods
        public static List<Movy> GetMovies()
        {
            var movieslist = new List<Movy>();
            using(var database = new movieLibraryEntities())
            {
                movieslist = database.Movies.ToList();

            }
            return movieslist;
        }
        #endregion

    }
}
