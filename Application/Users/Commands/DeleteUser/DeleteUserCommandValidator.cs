using Application.Products.Commands.DeleteProduct;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(deleteProductCommand =>
                deleteProductCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
