using Xunit;
using FluentAssertions;
using Moq;
using RocketseatAuction.API.Core.Contracts;
using RocketseatAuction.API.Core.UseCases.Auctions.GetCurrent;

namespace UseCases.test.Auctions.GetCurrent;

public class GetCurrentAuctionUseCaseTest
{
  [Fact]
  public void SuccessCase1()
  {
    // AAA test theory:
    // ARRANGE
    var repositoryMock = new Mock<IAuctionRepository>();
    
    var useCase = new GetCurrentAuctionUseCase(repositoryMock.Object);

    // ACT
    var auction = useCase.Execute();

    // ASSERT
    // Assert.NotNull(auction);
    auction.Should().NotBeNull();
  }
}