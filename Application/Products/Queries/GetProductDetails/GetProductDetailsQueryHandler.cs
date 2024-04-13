using Application.Common.Exceptions;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Products.Queries.GetProductDetails
{
    public class GetProductDetailsQueryHandler
        :IRequestHandler<GetProductDetailsQuery, Product>
    {
        private IDbContext _dbContext;

        private readonly IMapper _mapper;

        public GetProductDetailsQueryHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Product> Handle(GetProductDetailsQuery request, CancellationToken cancellationToken)
        {
            var product =
                await _dbContext.Products.FirstOrDefaultAsync(prod =>
                prod.Id == request.Id, cancellationToken);

            if (product == null)
                throw new NotFoundException(nameof(Product), request.Id);
            return product;
        }
    }
}
