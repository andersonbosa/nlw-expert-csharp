using RocketseatAuction.API.Core.Entities;

namespace RocketseatAuction.API.Core.Contracts;

public interface IOfferRepository
{
  void Add(Offer offer);
}