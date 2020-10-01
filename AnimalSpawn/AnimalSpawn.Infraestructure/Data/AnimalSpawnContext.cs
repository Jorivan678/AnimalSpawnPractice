using AnimalSpawn.Domain.Entities;
using AnimalSpawn.Infraestructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;


namespace AnimalSpawn.Infraestructure.Data
{
    public partial class AnimalSpawnContext : DbContext
    {
        public AnimalSpawnContext()
        {
        }

        public AnimalSpawnContext(DbContextOptions<AnimalSpawnContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Animal> Animal { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>(entity =>
            {
                modelBuilder.ApplyConfiguration<Animal>(new AnimalConfiguration());
            });
        }

    }
}
