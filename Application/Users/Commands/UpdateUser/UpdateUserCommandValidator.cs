using Application.Products.Commands.UpdateProduct;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(updUserComm =>
                updUserComm.Name).NotEmpty().MaximumLength(20);
            RuleFor(updUserComm =>
                updUserComm.Id).NotEqual(Guid.Empty);
            RuleFor(updUserComm =>
                updUserComm.PhoneNumber).NotEmpty().MaximumLength(40);
        }
    }
}
