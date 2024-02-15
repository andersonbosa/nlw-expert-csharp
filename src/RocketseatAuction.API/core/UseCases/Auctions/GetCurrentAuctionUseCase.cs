using Microsoft.EntityFrameworkCore;
using RocketseatAuction.API.Core.Entities;
using RocketseatAuction.API.Core.Repositories;

namespace RocketseatAuction.API.Core.UseCases.Auctions.GetCurrent;

public class GetCurrentAuctionUseCase
{
  public Auction? Execute()
  {
    var repository = new RocketseatAuctionDbContext();

    var today = DateTime.Now;

    return repository
        .Auctions
        .Include(auction => auction.Items)
        .FirstOrDefault(auction => today >= auction.Starts && today <= auction.Ends);
  }
}
