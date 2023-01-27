using Movies.Models;
using System.ComponentModel.DataAnnotations;

namespace Movies.Validators
{
    public class EightysMovieRatingsAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext) 
        {
            var movie = (Movie)validationContext.ObjectInstance;

            if (movie.Year >= 1980 && movie.Year < 1990 && movie.Rating < 2.5f) 
            {
                //when there is a problem
                return new ValidationResult("Movies cannot be bad in the 80s");
            }
            //input is valid
            return ValidationResult.Success;
        }
    }
}
