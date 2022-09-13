using MovieTracker.DBContexts;
using MovieTracker.Models.Entities;
using MovieTracker.Repository;
using MovieTracker.Services.Interfaces;

namespace MovieTracker.Services
{
    public class RolesService : IRolesService
    {
        private readonly IGenericRepository<Role, MovieTrackerContext> _repository;
        private readonly IMoviesService _moviesService;
        private readonly IActorsService _actorsService;

        public RolesService(IGenericRepository<Role, MovieTrackerContext> repository, IMoviesService moviesService, IActorsService actorsService)
        {
            _repository = repository;
            _moviesService = moviesService;
            _actorsService = actorsService;
        }

        public async Task<Role> CreateAsync(Role role)
        {
            var movie = await _moviesService.GetAsync(role.MovieId);
            var actor = await _actorsService.GetAsync(role.ActorId);

            return await _repository.InsertAsync(role);

        }

        public Task<Role> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Role> GetAsync(int id)
        {
            return await _repository.FindAsync(id);
        }

        public Task<Role> UpdateAsync(int id, Role rolet)
        {
            throw new NotImplementedException();
        }
    }
}
