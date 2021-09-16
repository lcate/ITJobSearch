using ITJobSearch.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;

namespace ITJobSearch.Infrastructure.Context
{
    public class ITJobSearchDbContext : DbContext
    {
        public ITJobSearchDbContext(DbContextOptions<ITJobSearchDbContext> options) : base(options) { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<JobOffer> JobOffers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<UserTest> UserTests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Will create the size of the column in the database as varchar(150) - where not specified
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(150)");

            // For each mapping class that we had configured, it will be registered through this command
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ITJobSearchDbContext).Assembly);

            // To disable the cascade deletion, do not want that when we delete one record from one table, the relational data in the other table be removed too
            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
    }
}
