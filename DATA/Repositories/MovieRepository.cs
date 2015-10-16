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
        public static List<Movy> SearchForMovies(string search)
        {
            var movieslist = new List<Movy>();
            using (var database = new movieLibraryEntities())
            {
                movieslist = database.Movies.Where(x=>x.Title.StartsWith(search)).ToList();

            }
            return movieslist;
        }
        public static Movy GetSpecificMovie(int id) 
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
        public static void UpdateMovie(Movy movie,int id)
        {
            using (var database = new movieLibraryEntities())
            {
                var movieToUpdate = database.Movies.Where(x => x.Id == id).FirstOrDefault();
                if (movieToUpdate != null)
                {
                    movieToUpdate.Title = movie.Title;
                    movieToUpdate.description = movie.description;
                    movieToUpdate.Director = movie.Director;
                    movieToUpdate.ImdbLink = movie.ImdbLink;
                    movieToUpdate.viewed = movie.viewed;
                    movieToUpdate.Rating = movie.Rating;
                    database.SaveChanges();
                }
            }
        }
        public static void RemoveMovie(int id)
        {
            using (var database = new movieLibraryEntities())
            {
                var movie = database.Movies.Where(x => x.Id == id).FirstOrDefault();
                database.Movies.Remove(movie);
                database.SaveChanges();
            }
        }
        #endregion

    }
}
