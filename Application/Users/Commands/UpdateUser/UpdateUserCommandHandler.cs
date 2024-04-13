using Application.Common.Exceptions;
using Application.Products.Commands.UpdateProduct;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IDbContext _dbContext;

        public UpdateUserCommandHandler(IDbContext dbContext) => _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var prod =
                await _dbContext.Users.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

            if (prod == null)
                throw new NotFoundException(nameof(Order), request.Id);

            prod.PhoneNumber = request.PhoneNumber;
            prod.Name = request.Name;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
