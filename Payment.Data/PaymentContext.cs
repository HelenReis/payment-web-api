using Microsoft.EntityFrameworkCore;
using Payment.Data.EntityConfiguration;
using Payment.Domain.Models;

namespace Payment.Data
{
    public class PaymentContext : DbContext
    {
        public PaymentContext(DbContextOptions<PaymentContext> options) : base(options) { }

        public DbSet<BankAccount> BankAccount { get; set; }

        public DbSet<Client> Client { get; set; }

        public DbSet<FinancialPosting> FinancialPosting { get; set; }

        public DbSet<Bank> Bank { get; set; }

        public DbSet<ImportedFile> ImportedFile { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BankAccountConfig());
            modelBuilder.ApplyConfiguration(new FinancialPostingConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}
