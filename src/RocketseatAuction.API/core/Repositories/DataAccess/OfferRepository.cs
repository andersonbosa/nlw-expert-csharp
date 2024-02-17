using Microsoft.EntityFrameworkCore;
using RocketseatAuction.API.Core.Contracts;
using RocketseatAuction.API.Core.Entities;

namespace RocketseatAuction.API.Core.Repositories.DataAccess;

public class OfferRepository : IOfferRepository
{
  private readonly RocketseatAuctionDbContext _dbContext;

  public OfferRepository(RocketseatAuctionDbContext dbContextInjection) => _dbContext = dbContextInjection;

  public void Add(Offer offer)
  {
    _dbContext.Offers.Add(offer);
    _dbContext.SaveChanges();
  }
}