namespace Movies.Models
{
    public class Movie
    {
        private static int nextID = 0;

        public int? Id{ get; set; } = nextID++;

        public string Title { get; set; } = "{NO TITLE}";

        public int? Year { get; set; } = 1888;

        public float? Rating { get; set; } = 0f;

        public DateTime? ReleaseDate { get; set; }

        public string Image { get; set; }
        public string Genre { get; set; }

        public Movie()
        { }

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
