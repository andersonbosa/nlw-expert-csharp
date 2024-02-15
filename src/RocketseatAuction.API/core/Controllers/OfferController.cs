using Microsoft.AspNetCore.Mvc;
using RocketseatAuction.API.Core.Communication.Requests;
using RocketseatAuction.API.Core.Filters;
using RocketseatAuction.API.Core.UseCases.Offers.CreateOffer;

namespace RocketseatAuction.API.Core.Controllers;

[ServiceFilter(typeof(AuthenticationUserAttribute))]
public class OfferController : RocketseatAuctionBaseController
{
  [HttpPost]
  [Route("{itemId}")]
  public IActionResult CreateOffer(
     [FromRoute] int itemId,
     [FromBody] RequestCreateOfferJson request,
     [FromServices] CreateOfferUseCase useCase
     )
  {
    var id = useCase.Execute(itemId, request);

    return Created(string.Empty, id);
  }
}