using Microsoft.EntityFrameworkCore;
using SipayApi.Data.Domain;

namespace SipayApi.Data;

public class SimDbContext : DbContext
{
    public SimDbContext()
    {
        
    }
    public SimDbContext(DbContextOptions<SimDbContext> options) : base(options)
    {

    }


    // dbset
    public DbSet<Customer>Customers { get; set; }
    public DbSet<Account> Account { get; set; }
    public DbSet<Transaction> Transaction { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AccountConfiguration());
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        modelBuilder.ApplyConfiguration(new TransactionConfiguration());

        base.OnModelCreating(modelBuilder);
    }



}
