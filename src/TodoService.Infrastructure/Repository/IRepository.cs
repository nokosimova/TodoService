using System.Collections.Generic;
using System.Threading.Tasks;
using TodoService.Domain.Entities;

namespace TodoService.Infrastructure.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<T> CreateAsync(T item);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(long id);
        Task DeleteAsync(T item);
        Task UpdateAsync(T item);
    }
}