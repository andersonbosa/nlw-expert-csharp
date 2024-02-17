using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RocketseatAuction.API.Core.Contracts;
using RocketseatAuction.API.Core.Repositories;

namespace RocketseatAuction.API.Core.Filters;

/* REFACTOR: UNSAVE AUTHORIZATION METHOD */
public class AuthenticationUserAttribute : AuthorizeAttribute, IAuthorizationFilter
{
  private IUserRepository _repository;

  public AuthenticationUserAttribute(IUserRepository repositoryInjection) => _repository = repositoryInjection;

  public void OnAuthorization(AuthorizationFilterContext context)
  {
    try
    {
      var token = TokenOnRequest(context.HttpContext);

      var emailFromToken = FromBase64String(token)?.Trim();

      var exist = _repository.ExistUserWithEmail(emailFromToken);
      if (exist == false)
      {
        context.Result = new UnauthorizedObjectResult("User not found");
      }
    }
    catch (Exception ex)
    {
      context.Result = new UnauthorizedObjectResult(ex.Message);
    }
  }

  private string TokenOnRequest(HttpContext context)
  {
    var authToken = context.Request.Headers.Authorization.ToString();

    /* REFACTOR: treat exception */
    if (string.IsNullOrEmpty(authToken))
    {
      throw new Exception("Token is missing");
    }

    return authToken["Bearer ".Length..];
  }

  private string FromBase64String(string base64)
  {
    var data = Convert.FromBase64String(base64);

    return System.Text.Encoding.UTF8.GetString(data);
  }
}