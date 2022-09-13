using FluentValidation;
using FluentValidation.AspNetCore;
using MovieTracker.Models.Dto;

namespace MovieTracker.util
{
    public static class Validators
    {
        public static void ConfigureValidators(this IServiceCollection services)
        {
            services.AddFluentValidation(fluentValidation =>
            {
                fluentValidation.ImplicitlyValidateChildProperties = true;
            });

            services.AddTransient<IValidator<MovieRequest>, MovieRequestValidator>();
            services.AddTransient<IValidator<ActorRequest>, ActorRequestValidator>();   
        }
    }
}
