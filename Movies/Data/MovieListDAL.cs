using Movies.Interfaces;
using Movies.Models;

namespace Movies.Data
{
    public class MovieListDAL : IDataAccessLayer
    {
        //HAS TO BE STATIC
        private static List<Movie> Movielist = new List<Movie>
        {
            new Movie("Star Wars: A New Hope", 1977, 4f),
            new Movie("Star Wars: The Empire Strikes Back", 1980, 4f),
            new Movie("Megamind", 2010, 5f),
        };

        public void AddMovie(Movie movie)
        {
            Movielist.Add(movie);
        }

        public void EditMovie(Movie m)
        {
            int i;
            i = GetMovie(m);
            Movielist[i] = m;
        }

        public Movie GetMovie(int? id)
        {
            //returns a specific movie
            return Movielist.Where(m => m.Id == id).FirstOrDefault();
        }

        public int GetMovie(Movie movie)
        {            
            return Movielist.FindIndex(x=> x.Id == movie.Id);
        }

        public IEnumerable<Movie> GetMovies()
        {
            //gets movielist
            return Movielist;
        }

        public void RemoveMovie(int? id)
        {
            //removes movie from list
            Movie foundMove = GetMovie(id);
            Movielist.Remove(foundMove);
        }
    }
}
