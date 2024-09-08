using DeliveryChannel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeliveryChannel.Infrastructure.Data.Configurations;

public class MenuItemEntityConfiguration : IEntityTypeConfiguration<MenuItem>
{
    public void Configure(EntityTypeBuilder<MenuItem> builder)
    {
        builder.HasKey(e => new { e.MenuId, e.ItemId });
    }
}