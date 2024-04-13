using Application.Common.Exceptions;
using Application.Orders.Commands.DeleteCommand;
using Application.Orders.Commands.UpdateOrder;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IDbContext _dbContext;

        public DeleteProductCommandHandler(IDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var prod =
                await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

            var orders = await _dbContext.Orders.ToListAsync();

            foreach (var order in orders)
            {
                if (order.ProductId == request.Id)                    
                    throw new Exception($"Продукт не может быть удален, так как в заказах у клиента есть продукт с id {prod.Id}");  
            }

            if (prod == null)
                throw new NotFoundException(nameof(Order), request.Id);

            _dbContext.Products.Remove(prod);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
