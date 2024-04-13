using Application.Orders.Queries.GetOrder;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.Queries.GetOrderList
{
    public class GetOrderListQueryValidator : AbstractValidator<GetOrderListQuery>
    {
        public GetOrderListQueryValidator()
        {
            RuleFor(order =>
                order.UserId).NotEqual(Guid.Empty);
        }
    }
}
