using Microsoft.IdentityModel.Tokens;
using MovieTracker.DBContexts;
using MovieTracker.Models.Entities;
using MovieTracker.Repository;
using MovieTracker.Services.Interfaces;

namespace MovieTracker.Services
{
    public class MoviesTypeService : IMoviesTypeService
    {
        private readonly IGenericRepository<MovieType, MovieTrackerContext> _repository;

        public MoviesTypeService(IGenericRepository<MovieType, MovieTrackerContext> repository)
        {
            _repository = repository;
        }

        public async IAsyncEnumerable<MovieType> FindAsync(int[] movieTypesId)
        {
      
            foreach(var item in movieTypesId)
            {
                var movieType = await _repository.FindAsync(item);

                yield return movieType;
            }
        }
    }
}
