﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.Queries.GetOrder
{
    public class GetOrderListQuery : IRequest<OrderListVm>
    {
        public Guid UserId { get; set; }
    }
}
