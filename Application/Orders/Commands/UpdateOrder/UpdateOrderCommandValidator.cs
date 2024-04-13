using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(updateOrderCommand =>
                updateOrderCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateOrderCommand =>
                updateOrderCommand.Description).NotEmpty().MaximumLength(250);
        }
    }
}
