using MediatR;
using Domain;


namespace Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : 
        IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IDbContext _dbContext;

        public CreateProductCommandHandler(IDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                Price = request.Price
            };

            await _dbContext.Products.AddAsync(product, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return product.Id;
        }
    }
}
