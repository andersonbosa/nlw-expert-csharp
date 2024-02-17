namespace RocketseatAuction.API.Core.Contracts;
using RocketseatAuction.API.Core.Entities;

public interface IAuctionRepository
{
  Auction? GetCurrent();
  Auction? GetByID(int id);
}
