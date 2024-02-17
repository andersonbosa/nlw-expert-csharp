using Xunit;
using FluentAssertions;
using Moq;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.UseCases.Auctions.GetCurrent;

namespace UseCases.test.Auctions.GetCurrent;

public class GetCurrentAuctionUseCaseTest
{
  [Fact]
  public void SuccessCase1()
  {
    // AAA test theory:
    // ARRANGE
    var auctionReturnExample = new Auction
    {
      Id = 1,
      Name = "name",
      Price = 300,
    };

    var repositoryMock = new Mock<IAuctionRepository>();
    repositoryMock
      .Setup(i => i.GetCurrent())
      .Returns(auctionReturnExample);

    var useCase = new GetCurrentAuctionUseCase(repositoryMock.Object);

    // ACT
    var auction = useCase.Execute();

    // ASSERT
    // Assert.NotNull(auction);
    auction.Should().NotBeNull();
  }
}