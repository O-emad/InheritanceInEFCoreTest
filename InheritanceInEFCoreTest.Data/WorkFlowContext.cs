using InheritanceInEFCoreTest.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace InheritanceInEFCoreTest.Data
{



    public class WorkFlowContext : DbContext
    {

        public WorkFlowContext()
        {

        }

        public WorkFlowContext(DbContextOptions<WorkFlowContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }

        public DbSet<Expenses> Expenses { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Expenses>().ToTable("Expenses");
            modelBuilder.Entity<Invoice>().ToTable("Invoices");
            modelBuilder.Entity<Transaction>().ToTable("Transaction");
        }

        public override int SaveChanges()
        {
            AddTimeStamp();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AddTimeStamp();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void AddTimeStamp()
        {
            var entities = ChangeTracker.Entries()
                .Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));
            foreach (var entity in entities)
            {
                var now = DateTime.UtcNow;
                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity)entity.Entity).CreatedAt = now;
                }
                ((BaseEntity)entity.Entity).UpdatedAt = now;
            }
        }
    }
}