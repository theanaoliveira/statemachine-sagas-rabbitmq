using Microsoft.EntityFrameworkCore;
using Sample.Sagas.Domain.Transfer;
using Sample.Sagas.Infrastructure.Database.Map;

namespace Sample.Sagas.Infrastructure.Database
{
    public class Context : DbContext
    {
        public DbSet<Domain.File> Files { get; set; }
        public DbSet<FileTransfer> FileTransfers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("MigrationInMemory");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FileMap());
            modelBuilder.ApplyConfiguration(new FileTransferMap());
        }
    }
}
