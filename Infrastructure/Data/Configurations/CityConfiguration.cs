using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> etp)
    {
        etp.HasIndex(c => c.Id).IsUnique().HasDatabaseName("OrderIdIndex");
        etp.Property(c => c.Id).HasColumnName("id").IsRequired();
        etp.Property(c => c.Name).HasColumnName("name").IsRequired();
    }
}