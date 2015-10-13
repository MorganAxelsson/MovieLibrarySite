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
        public static Movy getSpecificMovie(int id) 
        {
            using (var database = new movieLibraryEntities())
            {
                var movie = database.Movies.Where(x => x.Id == id).FirstOrDefault();
                return movie;
            }
          
        }
        public static void AddMovie(Movy movie)
        {
            using (var database = new movieLibraryEntities())
            {
                database.Movies.Add(movie);
                database.SaveChanges();
            }
        }
        #endregion

    }
}
