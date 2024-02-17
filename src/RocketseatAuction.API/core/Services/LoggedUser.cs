using RocketseatAuction.API.Core.Contracts;
using RocketseatAuction.API.Core.Entities;

namespace RocketseatAuction.API.Core.Services;

public class LoggedUser : ILoggedUser
{
  private readonly IHttpContextAccessor _httpContextAccessor;
  private readonly IUserRepository _repository;

  public LoggedUser(
    IHttpContextAccessor httpContextInjection,
    IUserRepository repositoryInjection
    )
  {
    _httpContextAccessor = httpContextInjection;
    _repository = repositoryInjection;
  }

  public User? User()
  {
    var token = TokenOnRequest();
    var email = FromBase64String(token).Trim();

    return _repository.GetUserByEmail(email);
  }

  private string TokenOnRequest()
  {
    var authentication = _httpContextAccessor.HttpContext!.Request.Headers.Authorization.ToString();

    return authentication["Bearer ".Length..];
  }

  private string FromBase64String(string base64)
  {
    var data = Convert.FromBase64String(base64);

    return System.Text.Encoding.UTF8.GetString(data);
  }
}