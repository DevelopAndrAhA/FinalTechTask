using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(updateProductCommand =>
                updateProductCommand.Name).NotEmpty().MaximumLength(40);
            RuleFor(updateProductCommand =>
                updateProductCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateProductCommand =>
                updateProductCommand.Description).NotEmpty().MaximumLength(250);
            RuleFor(createProductCommand =>
                createProductCommand.Price).GreaterThan(0);
        }
    }
}
