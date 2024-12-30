using Banking_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Banking_Project.Connection
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }  
        public DbSet<Account> Accounts { get; set; }    
        public DbSet<Transactionn> Transactions { get; set; }    
        public DbSet<BankCard> BankCards { get; set; }
    }
}
