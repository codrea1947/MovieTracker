using Microsoft.EntityFrameworkCore.Query;
using MovieTracker.Models.Entities;

namespace MovieTracker.Services.Interfaces
{
    public interface ICrudService<T>
        where T : class
    {
        public Task<T> CreateAsync(T t);
        public Task<T> GetAsync(int id);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> UpdateAsync(int id, T t);
        public Task<T> DeleteAsync(int id);
    }
}
