using JongBrabant.Kantinescherm.Models;
using Microsoft.EntityFrameworkCore;

namespace JongBrabant.Kantinescherm.Data;

public class PriceListContext : DbContext
{
    public PriceListContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GroupEntry>().HasData(new GroupEntry
        {
            GroupId = 1,
            GroupName = "Drank"
        },
            new GroupEntry
            {
                GroupName = "Broodjes",
                GroupId = 2
            });

        modelBuilder.Entity<ProductEntry>().HasData(new ProductEntry
        {
            GroupId = 1,
            ProductId = 1,
            Name = "Coca Cola",
            Price = 1.8m
        },
            new ProductEntry
            {
                GroupId = 1,
                ProductId = 2,
                Name = "Fanta",
                Price = 1.8m
            },
            new ProductEntry
            {
                Name = "Kroket",
                ProductId = 3,
                GroupId = 2,
                Price = 2.1m
            },
            new ProductEntry
            {
                Name = "Frikadel",
                ProductId = 4,
                GroupId = 2,
                Price = 2.10m
            },
            new ProductEntry
            {
                Name = "Jong Brabant",
                ProductId = 5,
                GroupId = 2,
                Price = 3.5m
            });
    }

    public DbSet<GroupEntry> Groups { get; set; }
    public DbSet<ProductEntry> Products { get; set; }
}