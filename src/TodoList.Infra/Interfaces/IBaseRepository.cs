using TodoList.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TodoList.Infra.Interfaces
{
    public interface IBaseRepository<T> where T : Base 
    {
        Task<T> CreateAsync(T obj);
        Task<T> GetByIdAsync(long id);
        Task<List<T>> GetAllAsync();
    }
}