using Microsoft.AspNetCore.Mvc;
using RocketseatAuction.API.Core.Entities;
using RocketseatAuction.API.Core.UseCases.Auctions.GetCurrent;
using RocketseatAuction.API.Core.UseCases.Auctions.GetAuctionByID;

namespace RocketseatAuction.API.Core.Controllers;

[Route("/api/v1/[controller]")]
[ApiController]
public class AuctionController : ControllerBase
{
  [HttpGet]
  [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  public IActionResult GetCurrentAuction()
  {
    var useCase = new GetCurrentAuctionUseCase();

    var result = useCase.Execute();

    if (result is null)
      return NoContent();

    return Ok(result);
  }

  [HttpGet("{id}")]
  [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  public IActionResult GetByID(int id)
  {
    var useCase = new GetAuctionByIDUseCase();

    var result = useCase.Execute(id);

    if (result is null)
      return NoContent();

    return Ok(result);
  }

}
