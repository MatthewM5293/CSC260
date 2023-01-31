using Movies.Models;
using System.Collections.Generic;

namespace Movies.Interfaces
{
    public interface IDataAccessLayer
    {
        IEnumerable<Movie> GetMovies(); //list of movies
        
        void AddMovie(Movie movie);
        
        void RemoveMovie(int? id);
        void EditMovie(Movie m);

        Movie GetMovie(int? id);

        int GetMovie(Movie movie);
    }
}
