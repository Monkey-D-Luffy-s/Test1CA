using Microsoft.AspNetCore.Mvc;
using Test1Core.DomainModels.Dtos;
using Test1Core.ServiceContracts;

namespace Test1CA.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
	private readonly IUserService _userService;
	public AuthController(IUserService userService)
	{
        _userService = userService;
	}

	[HttpPost("Register")]
	public async Task<IActionResult> RegisterUser(RegisterRequestDto? registerRequest)
	{
		try
		{
			if (registerRequest == null) return BadRequest(registerRequest);
			AuthenticationResponse response = await _userService.RegisterUser(registerRequest);
			if(response == null) return NotFound(registerRequest);
			return Ok(response);
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	[HttpPost("Login")]
	public async Task<IActionResult> LoginUser(LoginRequestDto loginRequest)
	{
		try
		{
			if (loginRequest == null) return BadRequest(loginRequest);
			AuthenticationResponse response = await _userService.LoginUser(loginRequest);
            if (response == null) return NotFound(loginRequest);
            return Ok(response);
        }
		catch (Exception ex)
		{

			throw ex;
		}
	}
}

