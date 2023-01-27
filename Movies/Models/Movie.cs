using Movies.Validators;
using System.ComponentModel.DataAnnotations;

namespace Movies.Models
{
    //applying validator to whole class
    [EightysMovieRatings]
    public class Movie
    {
        private static int nextID = 0;

        public int? Id{ get; set; } = nextID++;

        //set error message and string length
        [Required(ErrorMessage = "Movie Title is required, you dummy!")]
        [MaxLength(40)]
        public string Title { get; set; }

        [Required]
        [Range(1888, 2023, ErrorMessage = "No Movie was made in that year unless you time travelled!!!!")]
        public int? Year { get; set; }

        [Required]
        [Range(0.5f, 5f)]
        public float? Rating { get; set; } = 0f;

        public DateTime? ReleaseDate { get; set; }

        public string? Image { get; set; }
        public string? Genre { get; set; }

        public Movie() { }

        public Movie(int? id, string title, int? year, float? rating, DateTime? releaseDate, string image, string genre)
        {
            Id = id;
            Title = title;
            Year = year;
            Rating = rating;
            ReleaseDate = releaseDate;
            Image = image;
            Genre = genre;
        }
        
        public Movie(string title, int? year, float? rating)
        {
            Title = title;
            Year = year;
            Rating = rating;
        }

        public override string ToString()
        {
            return $"{Title} - {Year} - {Rating} stars";
        }
    }
}
