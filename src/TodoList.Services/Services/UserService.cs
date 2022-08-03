using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TodoList.Domain.Entities;
using TodoList.Infra.Interfaces;
using TodoList.Services.DTO;
using TodoList.Services.Interfaces;

namespace TodoList.Services.Services
{


    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;


        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserDto> CreateAsync(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            user.Validate();

            var userCreated = await _userRepository.CreateAsync(user);

            return _mapper.Map<UserDto>(userCreated);
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<List<UserDto>>(users);
        }

        public async Task<UserDto> GetByIdAsync(long id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return _mapper.Map<UserDto>(user);
        }
    }
}