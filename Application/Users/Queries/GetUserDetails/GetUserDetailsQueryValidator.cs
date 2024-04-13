using Application.Products.Queries.GetProductDetails;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUserDetails
{
    public class GetUserDetailsQueryValidator : AbstractValidator<GetProductDetailsQuery>
    {
        public GetUserDetailsQueryValidator()
        {
            RuleFor(p => p.Id).NotEqual(Guid.Empty);
        }
    }
}
