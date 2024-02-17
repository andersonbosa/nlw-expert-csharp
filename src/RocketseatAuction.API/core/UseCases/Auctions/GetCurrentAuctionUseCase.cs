using RocketseatAuction.API.Core.Contracts;
using RocketseatAuction.API.Core.Entities;

namespace RocketseatAuction.API.Core.UseCases.Auctions.GetCurrent;

public class GetCurrentAuctionUseCase
{
  private readonly IAuctionRepository _repository;
  public GetCurrentAuctionUseCase(IAuctionRepository repositoryInjection) => _repository = repositoryInjection;

  public Auction? Execute() => _repository.GetCurrent();
}
