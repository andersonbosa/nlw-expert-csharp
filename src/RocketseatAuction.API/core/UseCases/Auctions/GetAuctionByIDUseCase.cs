using Microsoft.EntityFrameworkCore;
using RocketseatAuction.API.Core.Entities;
using RocketseatAuction.API.Core.Repositories;

namespace RocketseatAuction.API.Core.UseCases.Auctions.GetAuctionByID;


public class GetAuctionByIDUseCase
{
  public Auction? Execute(int searchId)
  {
    var repository = new RocketseatAuctionDbContext();

    return repository
      .Auctions
      .FirstOrDefault(auction => auction.Id == searchId);

    //   return new Auction
    //   {
    //     Id = id,
    //     Name = "Leilão Exemplo",
    //     Starts = DateTime.Now.AddDays(1),
    //     Ends = DateTime.Now.AddDays(7)
    //   };
    // }
  }
}