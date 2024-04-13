using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.Queries.GetOrderDetails
{
    public class GetOrderDetailsQuery : IRequest<Order>
    {
        public Guid Id { get; set; }
    }
}
