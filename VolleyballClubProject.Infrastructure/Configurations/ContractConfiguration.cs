using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VolleyballClubProject.Core.Entities;

namespace VolleyballClubProject.Infrastructure.Configurations
{
    public class ContractConfiguration : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.HasData(
                    new Contract() { Id = 1, Name = "Health", CreatedTime = DateTime.Now },
                    new Contract() { Id = 2, Name = "Death", CreatedTime = DateTime.Now },
                    new Contract() { Id = 3, Name = "Memebership", CreatedTime = DateTime.Now }
            );
            builder.Property(x => x.Name).HasMaxLength(500).IsRequired();
        }
    }
}