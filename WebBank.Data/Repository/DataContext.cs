using WebBank.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;

namespace WebBank.Data.Repository
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<CashAccount> CashAccounts { get; set; }
        public DbSet<TransferTransaction> TransferTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<UserAccount>().ToTable("UserAccount");
            modelBuilder.Entity<CashAccount>().ToTable("CashAccount");
            modelBuilder.Entity<TransferTransaction>().ToTable("TransferTransaction");
        }
    }
}
