using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VolleyballClubProject.Core.Entities;

namespace VolleyballClubProject.Infrastructure.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product() { Id = 1, Name = "PC", CreatedTime = DateTime.Now },
                new Product() { Id = 2, Name = "Car", CreatedTime = DateTime.Now },
                new Product() { Id = 3, Name = "House", CreatedTime = DateTime.Now }
            );
            builder.Property(x => x.Name).HasMaxLength(500).IsRequired();
        }
    }
}