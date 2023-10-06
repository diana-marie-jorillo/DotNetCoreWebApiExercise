using Microsoft.EntityFrameworkCore;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {}

    //public DbSet<Accounts> Accounts { get;set; }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Accounts> Accounts { get; set; }
}