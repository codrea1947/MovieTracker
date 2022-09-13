using Microsoft.EntityFrameworkCore;
using MovieTracker.DBContexts;
using MovieTracker.Models.Entities;
using MovieTracker.Repository;
using MovieTracker.Services.Interfaces;

namespace MovieTracker.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly IGenericRepository<Movie, MovieTrackerContext> _repository;
        private readonly IMoviesTypeService _moviesTypeService;

        public MoviesService(
            IGenericRepository<Movie, MovieTrackerContext> repository, 
            IMoviesTypeService moviesTypeService)
        {
            _repository = repository;
            _moviesTypeService = moviesTypeService;
        }

        public async Task<Movie> CreateAsync(Movie movie)
        {
            return await _repository.InsertAsync(movie);
        }

        public async Task<Movie> CreateAsync(Movie movie, int[] moviesTypeId)
        {
            movie.MovieTypes = new List<MovieType>();

            await foreach (var result in _moviesTypeService.FindAsync(moviesTypeId))
            {
                movie.MovieTypes.Add(result);
            }
            return await CreateAsync(movie);
        }

        public async Task<Movie> DeleteAsync(int id)
        {
            var movie = _repository.FindAsync(id);

            if (movie == null)
            {
                return null;
            }

            await _repository.DeleteAsync(id);

            return await movie;
        }

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
            
        }

        public async Task<Movie> GetAsync(int id)
        {
            return await _repository.FindAsync(id);
        }

        public async Task<Movie> UpdateAsync(int id, Movie movie)
        {
            var existingMovie = await _repository.FindAsync(id);
            if (existingMovie == null)
            {
                return null;
            }

            return await _repository.UpdateAsync(id, movie);
        }

        public async Task<Movie> UpdateAsync(int id, Movie movie, int[] moviesTypeId)
        {
            movie.MovieTypes = new List<MovieType>();

            await foreach (var result in _moviesTypeService.FindAsync(moviesTypeId))
            {
                movie.MovieTypes.Add(result);
            }

            return await UpdateAsync(id, movie);
        }
    }
}
