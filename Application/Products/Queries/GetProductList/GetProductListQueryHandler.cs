using Application.Orders.Queries.GetOrder;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Queries.GetProductList
{
    public class GetProductListQueryHandler
        : IRequestHandler<GetProductListQuery, ProductListVm>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetProductListQueryHandler(IDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);
        

        public async Task<ProductListVm> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            var prodsQuery = await _dbContext.Products
                //.ProjectTo<ProductLookUpDto>(_mapper.ConfigurationProvider) Не смог разобраться с маппингом извините Мыктыбек байке или Нурлан байке ):
                .ToListAsync(cancellationToken);

            return new ProductListVm { Products = prodsQuery };
        }
    }
}
