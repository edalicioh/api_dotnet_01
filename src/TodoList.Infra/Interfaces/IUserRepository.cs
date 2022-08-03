
using System.Collections.Generic;
using System.Threading.Tasks;

using TodoList.Domain.Entities;

namespace TodoList.Infra.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
            
    }
}