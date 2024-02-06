using Microsoft.EntityFrameworkCore;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Repositories;

namespace RocketseatAuction.API.UseCases.Auctions.GetAuctionByID;


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