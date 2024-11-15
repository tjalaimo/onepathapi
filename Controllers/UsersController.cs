using Microsoft.AspNetCore.Mvc;
using onepathapi.Services;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public IActionResult Register()
    {
        var result = _userService.Register();
        return Ok(new { Message = result });
    }

    [HttpPost("login")]
    public IActionResult Login()
    {
        var token = _userService.Login();
        return Ok(new { Token = token });
    }

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        var result = _userService.Logout();
        return Ok(new { Message = result });
    }

    [HttpGet("me")]
    public IActionResult GetCurrentUser()
    {
        var user = _userService.GetCurrentUser();
        return Ok(user);
    }

    [HttpGet("getUser")]
    public IActionResult GetUser(int userId)
    {
        var user = _userService.GetUser(userId);
        return Ok(user);
    }
}
