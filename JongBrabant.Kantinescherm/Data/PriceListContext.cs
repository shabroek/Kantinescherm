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

        modelBuilder.Entity<PriceEntry>().HasData(new PriceEntry
        {
            GroupId = 1,
            PriceId = 1,
            Name = "Coca Cola",
            Price = 1.8m
        },
            new PriceEntry
            {
                GroupId = 1,
                PriceId = 2,
                Name = "Fanta",
                Price = 1.8m
            },
            new PriceEntry
            {
                Name = "Kroket",
                PriceId = 3,
                GroupId = 2,
                Price = 2.1m
            },
            new PriceEntry
            {
                Name = "Frikadel",
                PriceId = 4,
                GroupId = 2,
                Price = 2.10m
            },
            new PriceEntry
            {
                Name = "Jong Brabant",
                PriceId = 5,
                GroupId = 2,
                Price = 3.5m
            });
    }

    public DbSet<GroupEntry> Groups { get; set; }
    public DbSet<PriceEntry> Prices { get; set; }
}