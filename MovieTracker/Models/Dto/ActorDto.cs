using FluentValidation;
using MovieTracker.Models.Entities;

namespace MovieTracker.Models.Dto
{
    public class ActorRequest
    {
        public int CNP { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }

    public class ActorResponse
    {
        public int Id { get; set; }
        public int CNP { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }

    public class ActorForRoleResponse
    {
        public int Id { get; set; }
        public int CNP { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }

    public class ActorRequestValidator : AbstractValidator<ActorRequest>
    {
        public ActorRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.BirthDate).NotNull();
        }
    }
}
