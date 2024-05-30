using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

public class TokenController : ControllerBase
{
    private IConfiguration _config;

    public TokenController(IConfiguration config)
    {
        _config = config;
    }

    [HttpGet("generate")]
    public IActionResult GenerateToken()
    {
        var tokenString = GenerateJSONWebToken();
        return Ok(new { token = tokenString });
    }

    private string GenerateJSONWebToken()
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(_config["Jwt:Issuer"],
          _config["Jwt:Audience"],
          null,
          expires: DateTime.Now.AddHours(24),
          signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
