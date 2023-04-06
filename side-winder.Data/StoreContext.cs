using side.winder.Domain.Catalog;
using side.winder.Domain.Orders;
using Microsoft.EntityFrameworkCore;

namespace side.winder.Data
{
public class StoreContext : DbContext
{
    public StoreContext(DbContextOptions<StoreContext> options)
    : base(options)
    { }

    public DbSet<Item> Items { get; set; }

    public DbSet<Order> Orders {get; set;}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        DBInitializer.Initialize(builder);
    }
}
}
