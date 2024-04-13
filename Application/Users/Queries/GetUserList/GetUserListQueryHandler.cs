using Application.Products.Queries.GetProductList;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUserList
{
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, UserListVm>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUserListQueryHandler(IDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);


        public async Task<UserListVm> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var us = await _dbContext.Users
                //.ProjectTo<ProductLookUpDto>(_mapper.ConfigurationProvider) Не смог разобраться с маппингом извините Мыктыбек байке или Нурлан байке ):
                .ToListAsync(cancellationToken);

            return new UserListVm { Users = us };
        }
    }
}
