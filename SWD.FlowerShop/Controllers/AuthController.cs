using Microsoft.AspNetCore.Mvc;
using SWD.FlowerShop.Repos.Entities;
//using SWD.FlowerShop.Services;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    // Đăng ký người dùng mới
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] User user)
    {
        if (await _userService.Register(user))
        {
            return Ok(new { message = "User registered successfully" });
        }
        return BadRequest(new { message = "Username already exists" });
    }

    // Đăng nhập
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
    {
        var isAuthenticated = await _userService.Login(loginRequest.Username, loginRequest.Password);
        if (isAuthenticated)
        {
            return Ok(new { message = "Login successful" });
        }
        return Unauthorized(new { message = "Invalid credentials" });
    }
}

public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}
