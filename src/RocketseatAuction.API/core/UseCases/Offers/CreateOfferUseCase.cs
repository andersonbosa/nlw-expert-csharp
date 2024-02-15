using RocketseatAuction.API.Core.Communication.Requests;
using RocketseatAuction.API.Core.Entities;
using RocketseatAuction.API.Core.Repositories;
using RocketseatAuction.API.Core.Services;

namespace RocketseatAuction.API.Core.UseCases.Offers.CreateOffer;


public class CreateOfferUseCase
{

  private readonly LoggedUser _loggedUser;

  public CreateOfferUseCase(LoggedUser loggedUser) => _loggedUser = loggedUser;

  public int Execute(int itemId, RequestCreateOfferJson request)
  {

    var repository = new RocketseatAuctionDbContext();

    var user = _loggedUser.User();

    var offerEntity = new Offer
    {
      CreatedOn = DateTime.Now,
      Price = request.Price,
      ItemId = itemId,
      UserId = user.Id,
    };

    repository.Offers.Add(offerEntity);

    repository.SaveChanges();

    return offerEntity.Id;
  }
}
