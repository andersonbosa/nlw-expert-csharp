using RocketseatAuction.API.Core.Entities;

namespace RocketseatAuction.API.Core.Contracts;

public interface IUserRepository
{
  bool ExistUserWithEmail(string email);
  User? GetUserByEmail(string email);
}
