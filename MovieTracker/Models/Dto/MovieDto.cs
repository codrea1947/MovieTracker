using FluentValidation;
using MovieTracker.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace MovieTracker.Models.Dto
{
    public class MovieRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int[] MovieTypesId { get; set; }
    }

    public class MovieResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<MovieTypeDto> MovieTypes { get; set; }

    }

    public class MovieRequestValidator: AbstractValidator<MovieRequest>
    {
        public MovieRequestValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(50);
            RuleFor(x => x.MovieTypesId).NotEmpty();
        }
    }
}
