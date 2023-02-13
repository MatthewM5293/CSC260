using Movies.Interfaces;
using Movies.Models;

namespace Movies.Data
{
    public class MovieListDAL : IDataAccessLayer
    {
        ////HAS TO BE STATIC
        //private static List<Movie> Movielist = new List<Movie>
        //{
        //    new Movie("Star Wars: A New Hope", 1977, 4f),
        //    new Movie("Star Wars: The Empire Strikes Back", 1980, 4f),
        //    new Movie("Megamind", 2010, 5f),
        //};

        private AppDbContext db;
        public MovieListDAL(AppDbContext indb)
        {
            db = indb;
        }

        public void AddMovie(Movie movie)
        {
            db.Movies.Add(movie);
            db.SaveChanges(); //must save db changed or it won't work
        }

        public void EditMovie(Movie m)
        {
            db.Movies.Update(m);
            db.SaveChanges();
        }

        public Movie GetMovie(int? id)
        {
            //returns a specific movie
            return db.Movies.Where(m => m.Id == id).FirstOrDefault();
        }

        //public int GetMovie(Movie movie)
        //{
        //    //return Movielist.FindIndex(x=> x.Id == movie.Id);
        //    return 0;
        //}

        public IEnumerable<Movie> GetMovies()
        { 
            return db.Movies.ToList();

            //sort list (by year)
            //return db.Movies.OrderBy(m => m.Year).ToList();
        }

        public void RemoveMovie(int? id)
        {
            //removes movie from list
            Movie foundMove = GetMovie(id);
            db.Movies.Remove(foundMove);
            db.SaveChanges(); //save changes
        }

        public IEnumerable<Movie> FilterMovies(string genre, string mpaRating)
        {
            //simple fix
            if (genre == null) genre = String.Empty;
            if (mpaRating == null) mpaRating = String.Empty;

            if (genre == "" && mpaRating == "") return GetMovies(); //returns if both empty

            IEnumerable<Movie> lstMovies = GetMovies().Where(m => (!String.IsNullOrEmpty(m.Genre) && m.Genre.ToLower().Contains(genre.ToLower()))).ToList();
            IEnumerable<Movie> lstMovies2 = lstMovies.Where(m => (!String.IsNullOrEmpty(m.MPARATING) && m.MPARATING.ToLower().Equals(mpaRating.ToLower()))).ToList();

            if (lstMovies2.Count() == 0) return lstMovies; //returns only genre

            return lstMovies2; //returns rating and/or genre
        }

    }
}
