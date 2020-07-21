using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data
{
    public class DataContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Door> Doors { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<CompletedRoom> CompletedRooms { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // disable cascade delete
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        public class EFDBContextFactory : IDesignTimeDbContextFactory<DataContext>
        {
            public DataContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=RoomsAndDoorsDb;Trusted_Connection=True;MultipleActiveResultSets=true", b => b.MigrationsAssembly("Data"));
                return new DataContext(optionsBuilder.Options);
            }
        }

    }
}
