using MediatR;
using Domain;

namespace Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<Guid>
    {
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        public string Description { get; set; }
    }
}
