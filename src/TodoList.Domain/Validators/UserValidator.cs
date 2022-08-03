
using FluentValidation;
using TodoList.Domain.Entities;

namespace TodoList.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A Entidade não pode ser vazia.");
                
            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("O Nome não podes ser nulo")

                .NotEmpty()
                .WithMessage("O nome não pode ser vazio")

                .MinimumLength(3)
                .WithMessage("O nome deve ter no minimo 3 caracteres.")

                .MaximumLength(50)
                .WithMessage("O nome deve ter no maximo 50 caracteres.");

            RuleFor(x => x.Email)
                .NotNull()
                .WithMessage("O email não podes ser nulo")

                .NotEmpty()
                .WithMessage("O email não pode ser vazio")

                .Matches(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
                .WithMessage("O email informado não e válido");

            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("A senha nao podes ser nulo")

                .NotEmpty()
                .WithMessage("A senha não pode ser vazio")

                .MinimumLength(6)
                .WithMessage("A senha deve ter no minimo 6 caracteres.");
        }


    }
}