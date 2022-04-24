using JwtAuthentification.Contracts.V1;
using JwtAuthentification.Contracts.V1.Requests;
using JwtAuthentification.Contracts.V1.Responces;

using Microsoft.AspNetCore.Mvc;

namespace JwtAuthentification.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class IdentityController : ControllerBase
{
    private readonly IIdentityService _identityService;

    public IdentityController(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    [HttpPost(ApiRoutes.Identity.Register)]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        AuthentificationResult authResult = await _identityService.RegisterAsync(request.Email, request.Password);

        return Ok(new RegisterResponce
        {
            Token = authResult.Token
        });
    }
}
