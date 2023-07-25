using Domain.Entities;
namespace Application.Common.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<Domain.Entities.City> Cities { get; set; }
    public DbSet<Domain.Entities.Order> Orders { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}