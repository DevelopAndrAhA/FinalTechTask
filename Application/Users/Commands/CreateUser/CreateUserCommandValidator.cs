using Application.Orders.Commands.CreateOrder;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(createOrderCommand =>
                createOrderCommand.Name).NotEmpty().MaximumLength(20);
        }
    }
}
