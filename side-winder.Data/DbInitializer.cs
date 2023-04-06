using side.winder.Domain.Catalog;
using Microsoft.EntityFrameworkCore;

namespace side.winder.Data
{
    public static class DBInitializer
    {
        public static void Initialize(ModelBuilder builder)
        {
            builder.Entity<Item>().HasData(
                new Item("Shirt", "Ohio State shirt", "Nike", 29.99M)
                {
                    ID = 1
                },
                new Item("Shorts", "Ohio State shorts", "Nike", 44.99m)
                {
                    ID = 2
                }
            );
        }
    }
}