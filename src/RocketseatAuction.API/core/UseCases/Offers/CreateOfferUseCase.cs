using RocketseatAuction.API.Core.Communication.Requests;
using RocketseatAuction.API.Core.Contracts;
using RocketseatAuction.API.Core.Entities;
using RocketseatAuction.API.Core.Services;

namespace RocketseatAuction.API.Core.UseCases.Offers.CreateOffer;

public class CreateOfferUseCase
{
    private readonly ILoggedUser _loggedUser;
    private readonly IOfferRepository _repository;

    public CreateOfferUseCase(ILoggedUser loggedUser, IOfferRepository repository)
    {
        _loggedUser = loggedUser;
        _repository = repository;
    }

    public int Execute(int itemId, RequestCreateOfferJson request)
    {
        var user = _loggedUser.User();

        var offer = new Offer
        {
            CreatedOn = DateTime.Now,
            ItemId = itemId,
            Price = request.Price,
            UserId = user.Id,
        };

        _repository.Add(offer);

        return offer.Id;
    }
}