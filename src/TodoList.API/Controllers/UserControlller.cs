using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TodoList.API.Utilities;
using TodoList.API.ViewModels;
using TodoList.Core.Exceptions;
using TodoList.Services.DTO;
using TodoList.Services.Interfaces;

namespace TodoList.API.Controllers
{
    [ApiController]
    public class UserControlller : ControllerBase
    {
        private readonly IUserService _userService;
        protected readonly IMapper _mapper;

        public UserControlller(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("/api/v1/user")]
        public async Task<IActionResult> CreateAsync([FromBody] CreateUserViewModel model) 
        {
            try
            {

                var userDto = _mapper.Map<UserDto>(model);
                var user = await _userService.CreateAsync(userDto);

                return Ok(new ResponseViewModel{
                    Message = "Usuario criado com sucesso",
                    Success = true,
                    Data = user,

                });
            }
            
            catch (DomainException ex)
            {
                return BadRequest(ResponseError.DomainErrorMessage(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); 
            }
        }
    }
}