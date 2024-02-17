using Xunit;
using FluentAssertions;
using RocketseatAuction.API.Core.UseCases.Auctions.GetCurrent;

namespace UseCases.test.Auctions.GetCurrent;

public class GetCurrentAuctionUseCaseTest
{
  [Fact]
  public void SuccessCase1()
  {
    // AAA test theory:
    // ARRANGE
    var useCase = new GetCurrentAuctionUseCase(null);

    // ACT
    var auction = useCase.Execute();

    // ASSERT
    // Assert.NotNull(auction);
    auction.Should().NotBeNull();
  }
}