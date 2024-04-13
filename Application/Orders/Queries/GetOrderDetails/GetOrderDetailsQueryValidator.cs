using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.Queries.GetOrderDetails
{
    public class GetOrderDetailsQueryValidator : AbstractValidator<GetOrderDetailsQuery>
    {
        public GetOrderDetailsQueryValidator()
        {
            RuleFor(order =>
                order.Id).NotEqual(Guid.Empty);
        }
    }
}
