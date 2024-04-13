using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(createProductCommand =>
                createProductCommand.Price).GreaterThan(0);
            RuleFor(createProductCommand =>
                createProductCommand.Name).NotEmpty().MaximumLength(40);
            RuleFor(createProductCommand =>
                createProductCommand.Description).NotEmpty().MaximumLength(250);
        }
    }
}

