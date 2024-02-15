using RocketseatAuction.API.Core.Repositories;

public class AuctionRepository
{
  private readonly RocketseatAuctionDbContext _dbContext;
  public AuctionRepository(RocketseatAuctionDbContext dbContext) => _dbContext = dbContext
}