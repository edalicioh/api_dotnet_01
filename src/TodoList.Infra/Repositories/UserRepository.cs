using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TodoList.Domain.Entities;
using TodoList.Infra.Context;
using TodoList.Infra.Interfaces;

namespace TodoList.Infra.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(TodoContext context) : base(context)
        {
        }
    }


}