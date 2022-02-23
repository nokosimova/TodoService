using System.Collections.Generic;
using System.Threading.Tasks;
using TodoService.Domain.Entities;

namespace TodoService.Infrastructure.Repository
{
    public interface IRepository<T> where T : class
    {
        Task CreateAsync(T item);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task DeleteAsync(T item);
        Task UpdateAsync(T item);
    }
}