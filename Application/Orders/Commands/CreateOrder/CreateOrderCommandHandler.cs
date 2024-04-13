using MediatR;
using Application.Orders.Commands.CreateOrder;
using Domain;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler :
        IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IDbContext _dbContext;

        public CreateOrderCommandHandler(IDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == request.UserId);
            if (user == null)            
                throw new Exception($"User with Id {request.UserId} not found");

            var product = _dbContext.Products.FirstOrDefaultAsync(p => p.Id == request.ProductId);
            if (user == null)
                throw new Exception($"Product with Id {product.Id} not found");

            var order = new Order
            {
                Description = request.Description,
                Id = Guid.NewGuid(),
                ProductId = request.ProductId,
                UserId = request.UserId,
                CreateDate = DateTime.Now,
                EditDate = null
            };            

            await _dbContext.Orders.AddAsync(order, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return order.Id;            
        }
    }
}
