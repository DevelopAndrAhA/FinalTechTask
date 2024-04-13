using Application.Orders.Commands.DeleteCommand;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
    {
        public DeleteOrderCommandValidator()
        {
            RuleFor(deleteOrderCommand =>
                deleteOrderCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
