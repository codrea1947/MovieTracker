using MovieTracker.Models.Entities;

namespace MovieTracker.Services.Interfaces
{
    public interface IMoviesTypeService
    {
        public IAsyncEnumerable<MovieType> FindAsync(int[] movieTypesId);
    }
}
