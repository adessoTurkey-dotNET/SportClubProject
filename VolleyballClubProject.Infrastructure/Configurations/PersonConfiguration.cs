using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VolleyballClubProject.Core.Entities;

namespace VolleyballClubProject.Infrastructure.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasData(
                new Person() { Id = 1, Gender = "M", Name = "Ferruh", CreatedTime = DateTime.Now },
                new Person() { Id = 2, Gender = "F", Name = "Merve", CreatedTime = DateTime.Now },
                new Person() { Id = 3, Gender = "M", Name = "Mahmut", CreatedTime = DateTime.Now }
            );
            builder.Property(x => x.Name).HasMaxLength(500).IsRequired();
        }
    }
}