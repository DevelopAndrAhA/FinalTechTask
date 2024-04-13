using Application.Common.Exceptions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler
        : IRequestHandler<UpdateProductCommand>
    {
        private readonly IDbContext _dbContext;

        public UpdateProductCommandHandler(IDbContext dbContext) => _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var prod =
                await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

            if (prod == null)            
                throw new NotFoundException(nameof(Order), request.Id);            
            
            prod.Description = request.Description;
            prod.Price = request.Price;
            prod.Name = request.Name;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
