using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using VolleyballClubProject.Core.Common;
using VolleyballClubProject.Core.Entities;

namespace VolleyballClubProject.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt) : base(opt)
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt, IConfiguration configuration) : base(opt)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReference)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                        {
                            entityReference.CreatedTime = DateTime.Now;
                            break;
                        }
                        case EntityState.Modified:
                        {
                            Entry(entityReference).Property(x => x.CreatedTime).IsModified = false;
                            break;
                        }
                    }
                }
            }
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReference)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                        {
                            entityReference.CreatedTime = DateTime.Now;
                            break;
                        }
                        case EntityState.Modified:
                        {
                            Entry(entityReference).Property(x => x.CreatedTime).IsModified = false;
                            break;
                        }
                    }
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("connectionString"), x => x.MigrationsAssembly("VolleyballClubProject.Infrastructure"));
                base.OnConfiguring(optionsBuilder);
            }
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}
