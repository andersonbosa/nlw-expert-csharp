using Microsoft.EntityFrameworkCore;
using RocketseatAuction.API.Core.Contracts;
using RocketseatAuction.API.Core.Entities;

namespace RocketseatAuction.API.Core.UseCases.Auctions.GetAuctionByID;

public class GetAuctionByIDUseCase
{
  private readonly IAuctionRepository _repository;
  public GetAuctionByIDUseCase(IAuctionRepository repositoryInjection) => _repository = repositoryInjection;

  public Auction? Execute(int id) => _repository.GetByID(id);
}