using Application.Common.Exceptions;
using Application.Products.Queries.GetProductDetails;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUserDetails
{
    public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, User>
    {
        private IDbContext _dbContext;

        private readonly IMapper _mapper;

        public GetUserDetailsQueryHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<User> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
        {
            var user =
                await _dbContext.Users.FirstOrDefaultAsync(prod =>
                prod.Id == request.Id, cancellationToken);

            if (user == null)
                throw new NotFoundException(nameof(Product), request.Id);
            return user;
        }
    }
}
