using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Services.DTO;

namespace TodoList.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> CreateAsync(UserDto userDto);
        Task<UserDto> GetByIdAsync(long id);
        Task<List<UserDto>> GetAllAsync();
    }
}