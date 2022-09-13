using Microsoft.Extensions.DependencyInjection;
using MovieTracker.Services;
using MovieTracker.Services.Interfaces;

namespace MovieTracker.Helpers
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCrudServices(this IServiceCollection services)
        {
            return services.AddScoped<IMoviesService, MoviesService>()
                           .AddScoped<IUserService, UserService>()
                           .AddScoped<IActorsService, ActorsService>()
                           .AddScoped<IMoviesTypeService, MoviesTypeService>()
                           .AddScoped<IRolesService, RolesService>();

        }
    }
}
