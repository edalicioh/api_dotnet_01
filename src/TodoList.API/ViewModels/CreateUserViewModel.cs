using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.API.ViewModels
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage = "O nome é requerido")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O email é requerido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O senha é requerido")]
        public string Password { get; set; }
    }
}