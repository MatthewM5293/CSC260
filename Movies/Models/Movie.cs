using Movies.Validators;
using System.ComponentModel.DataAnnotations;

namespace Movies.Models
{
    //applying validator to whole class
    [EightysMovieRatings]
    public class Movie
    {
        [Key]
        public int Id{ get; set; }

        //set error message and string length
        [Required(ErrorMessage = "Movie Title is required, you dummy!")]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [Range(1888, 2023, ErrorMessage = "No Movie was made in that year unless you time travelled!!!!")]
        public int? Year { get; set; }

        [Required]
        [Range(1, 5)]
        public float? Rating { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public string? Image { get; set; }
        public string? Genre { get; set; }
        public string? MPARATING { get; set; } //g, pg, pg-13, R

        //needed
        public Movie() { }

        public Movie(int id, string title, int? year, float? rating, DateTime? releaseDate, string image, string genre)
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
