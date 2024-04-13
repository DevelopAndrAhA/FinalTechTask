using Application.Common.Exceptions;
using Application.Products.Commands.DeleteProduct;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IDbContext _dbContext;

        public DeleteUserCommandHandler(IDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var us =
                await _dbContext.Users.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

            if (us == null)
                throw new NotFoundException(nameof(Order), request.Id);

            var orders = await _dbContext.Orders.ToListAsync();

            foreach (var order in orders)
            {
                if (order.UserId == request.Id)
                    throw new Exception($"Клиент не может быть удален так как он ждет своего заказа {us.Name}");
            }

            _dbContext.Users.Remove(us);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
