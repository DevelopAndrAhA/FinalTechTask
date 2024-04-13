using Application.Products.Commands.CreateProduct;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler :
        IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IDbContext _dbContext;

        public CreateUserCommandHandler(IDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                PhoneNumber = request.PhoneNumber
            };

            await _dbContext.Users.AddAsync(user, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
    }
}
