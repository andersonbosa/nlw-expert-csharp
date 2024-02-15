using Microsoft.EntityFrameworkCore;
using RocketseatAuction.API.Core.Entities;

namespace RocketseatAuction.API.Core.Repositories;

public class RocketseatAuctionDbContext : DbContext
{
    public DbSet<Auction> Auctions { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Offer> Offers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source=/home/t4inha/devspace/nlw-expert-csharp/src/RocketseatAuction.API/data/leilaoDbNLW.db");
    }
}
