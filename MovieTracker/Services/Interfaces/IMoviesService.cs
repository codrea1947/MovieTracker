using MovieTracker.Models.Entities;

namespace MovieTracker.Services.Interfaces
{
    public interface IMoviesService: ICrudService<Movie>
    {
       public Task<Movie> CreateAsync(Movie t, int[] moviesTypeId);
       public Task<Movie> UpdateAsync(int id, Movie t, int[] moviesTypeId);
    }
}
