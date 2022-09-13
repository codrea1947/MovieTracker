using MovieTracker.DBContexts;
using MovieTracker.Models.Entities;
using MovieTracker.Repository;
using MovieTracker.Services.Interfaces;

namespace MovieTracker.Services
{
    public class ActorsService : IActorsService
    {
        private readonly IGenericRepository<Actor, MovieTrackerContext> _repository;

        public ActorsService(IGenericRepository<Actor, MovieTrackerContext> repository)
        {
            _repository = repository;
        }

        public async Task<Actor> CreateAsync(Actor actor)
        {
            return await _repository.InsertAsync(actor);
        }

        public async Task<Actor> DeleteAsync(int id)
        {
            var actor = _repository.FindAsync(id);

            if (actor == null)
            {
                return null;
            }    
            await _repository.DeleteAsync(id);

            return await actor;
        }

        public async Task<IEnumerable<Actor>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Actor> GetAsync(int id)
        {
            return await _repository.FindAsync(id);
        }

        public async Task<Actor> UpdateAsync(int id, Actor actor)
        {
            var existingActor = await _repository.FindAsync(id);
            if (existingActor == null)
                return null;

            return await _repository.UpdateAsync(id, actor);
        }
    }
}
