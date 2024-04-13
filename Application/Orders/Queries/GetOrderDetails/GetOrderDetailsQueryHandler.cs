using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Application.Common.Exceptions;
using Domain;

namespace Application.Orders.Queries.GetOrderDetails
{
    public class GetOrderDetailsQueryHandler
        :IRequestHandler<GetOrderDetailsQuery, Order>
    {
        private IDbContext _dbContext;

        private readonly IMapper _mapper;

        public GetOrderDetailsQueryHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Order> Handle(GetOrderDetailsQuery request, CancellationToken cancellationToken)
        {
            var order =
                await _dbContext.Orders.FirstOrDefaultAsync(order =>
                order.Id == request.Id, cancellationToken);

            if (order == null)           
                throw new NotFoundException(nameof(Order), request.Id);
            return order;
        }
    }
}
