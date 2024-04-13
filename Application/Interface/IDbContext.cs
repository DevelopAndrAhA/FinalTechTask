using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application
{
    public interface IDbContext
    {
        DbSet<Order> Orders { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<User> Users { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
