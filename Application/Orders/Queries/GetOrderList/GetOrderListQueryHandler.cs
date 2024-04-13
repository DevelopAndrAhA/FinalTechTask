using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.Queries.GetOrder
{
    public class GetOrderListQueryHandler
        : IRequestHandler<GetOrderListQuery, OrderListVm>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetOrderListQueryHandler(IDbContext dbContext, IMapper mapper)
            => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<OrderListVm> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
        {
            var ordersQuery = await _dbContext.Orders
                //.ProjectTo<OrderLookupDto>(_mapper.ConfigurationProvider) Не смог разобраться с маппингом извините Мыктыбек байке или Нурлан байке ):
                .ToListAsync(cancellationToken);

            return new OrderListVm { Orders = ordersQuery };
        }
    }
}
