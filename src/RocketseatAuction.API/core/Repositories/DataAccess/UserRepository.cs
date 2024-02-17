using Microsoft.EntityFrameworkCore;
using RocketseatAuction.API.Core.Contracts;
using RocketseatAuction.API.Core.Entities;

namespace RocketseatAuction.API.Core.Repositories.DataAccess;

public class UserRepository : IUserRepository
{
  private readonly RocketseatAuctionDbContext _dbContext;

  public UserRepository(RocketseatAuctionDbContext dbContextInjection) => _dbContext = dbContextInjection;

  public bool ExistUserWithEmail(string email)
  {
    return _dbContext.Users.Any(user => user.Email.Equals(email));
  }

  public User? GetUserByEmail(string email) {
    return _dbContext.Users.First(user => user.Email.Equals(email));
  }
}