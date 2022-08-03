using System;
using System.Collections.Generic;
using TodoList.Core.Exceptions;
using TodoList.Domain.Validators;

namespace TodoList.Domain.Entities
{
    public class User : Base
    {


        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        protected User() { }

        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
            _errors = new List<string>();
        }

        public void ChangeName(string name)
        {
            Name = name;
            Validate();
        }

         public void ChangeEmail(string email)
        {
            Email = email;
            Validate();
        }
         public void ChangePassword(string password)
        {
            Password = password;
            Validate();
        }

        public override bool Validate()
        {
            var validator = new UserValidator();
            var validation = validator.Validate(this);

            if(!validation.IsValid) 
            {
                foreach (var erro in validation.Errors)
                {
                    _errors.Add(erro.ErrorMessage);
                }

                throw new DomainException("deu erro", _errors);
            }
            return true;

        }
    }
}