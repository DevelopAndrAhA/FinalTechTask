using MediatR;
using Microsoft.EntityFrameworkCore;
using Application.Common.Exceptions;
using Domain;

namespace Application.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler 
        : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IDbContext _dbContext;

        public UpdateOrderCommandHandler(IDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order =
                await _dbContext.Orders.FirstOrDefaultAsync(order => order.Id == request.Id, cancellationToken);

            if (order == null)           
                throw new NotFoundException(nameof(Order), request.Id);            

            order.Description = request.Description;
            order.EditDate = DateTime.Now;            

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
