
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoList.Domain.Entities;
using TodoList.Infra.Context;
using TodoList.Infra.Interfaces;

namespace TodoList.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Base
    {
        private readonly TodoContext DbContext ;

        public BaseRepository(TodoContext context)
        {
            DbContext = context;
        }

        public async Task<T> CreateAsync(T obj)
        {
            DbContext.Add(obj);
            await DbContext.SaveChangesAsync();
            return obj;
        }

        public async Task<List<T>> GetAllAsync() => await DbContext.Set<T>().ToListAsync();        

        public async Task<T> GetByIdAsync(long id) => await DbContext.Set<T>().FindAsync(id);
    }
}