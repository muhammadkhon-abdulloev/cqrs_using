using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations;

public class OrderConfiguration: IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> etp)
    {
        etp.ToTable("order")
            .HasIndex(o => o.Id)
            .IsUnique()
            .HasDatabaseName("OrderIdIndex");
        etp.Property(o => o.Id)
            .HasColumnName("id")
            .IsRequired();
        
        etp.Property(o => o.SenderCityId)
            .HasColumnName("sender_city_id")
            .IsRequired();
        etp.HasOne(o => o.SenderCity)
            .WithMany(c => c.SenderOrders)
            .HasForeignKey(o => o.SenderCityId);

        etp.Property(o => o.ReceiverCityId)
            .HasColumnName("receiver_city_id")
            .IsRequired();
        etp.HasOne(o => o.ReceiverCity)
            .WithMany(c => c.ReceiverOrders)
            .HasForeignKey(o => o.ReceiverCityId);
        
        etp.Property(o => o.SenderAddress)
            .HasColumnName("sender_address")
            .IsRequired();

        etp.Property(o => o.ReceiverAddress)
            .HasColumnName("receiver_address")
            .IsRequired();
        etp.Property(o => o.CargoWeight)
            .HasColumnName("cargo_weight")
            .IsRequired()
            .HasColumnType("numeric");
        etp.Property(o => o.PickupDate)
            .HasColumnName("pickup_date")
            .IsRequired();
        etp.Property(o => o.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired()
            .HasColumnType("timestamptz")
            .HasDefaultValue();
    }
}