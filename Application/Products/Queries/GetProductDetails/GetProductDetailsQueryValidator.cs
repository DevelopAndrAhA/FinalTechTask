using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Queries.GetProductDetails
{
    public class GetProductDetailsQueryValidator : AbstractValidator<GetProductDetailsQuery>
    {
        public GetProductDetailsQueryValidator()
        {
            RuleFor(p => p.Id).NotEqual(Guid.Empty);
        }
    }
}
