using Application.Common.Exceptions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Orders.Commands.DeleteCommand
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly IDbContext _dbContext;

        public DeleteOrderCommandHandler(IDbContext dbContext) 
            => _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = 
                await _dbContext.Orders.FindAsync(new object[] { request.Id }, cancellationToken);

            if (order == null)            
                throw new NotFoundException(nameof(Order), request.Id);
            
            _dbContext.Orders.Remove(order);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
