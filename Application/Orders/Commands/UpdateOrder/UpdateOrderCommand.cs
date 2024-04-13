using MediatR;
using System;

namespace Application.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
    }
}
