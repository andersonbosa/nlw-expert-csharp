using Microsoft.EntityFrameworkCore;
using RocketseatAuction.API.Core.Contracts;
using RocketseatAuction.API.Core.Entities;

namespace RocketseatAuction.API.Core.Repositories.DataAccess;

public class AuctionRepository : IAuctionRepository
{
  private readonly RocketseatAuctionDbContext _dbContext;
  public AuctionRepository(RocketseatAuctionDbContext dbContextInjection) => _dbContext = dbContextInjection;

  public Auction? GetCurrent()
  {
    var today = DateTime.Now;

    return _dbContext
            .Auctions
            .Include(auction => auction.Items)
            .FirstOrDefault(auction => today >= auction.Starts);
  }

  public Auction? GetByID(int id)
  {
    return _dbContext
            .Auctions
            .FirstOrDefault(auction => auction.Id == id);
  }
}