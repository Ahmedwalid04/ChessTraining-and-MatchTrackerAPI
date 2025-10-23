using ChessTrainingApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
namespace ChessTrainingApi.Services;
public class AuthServices(IUserServices userService, IConfiguration configuration) : IAuthServices
{
    public async ValueTask<User> RegisterAsync(User user)
    {
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        await userService.AddUserAsync(user);
        return user;
    }

    public async ValueTask<AuthResponse> LoginAsync(string username, string password)
    {
        var users = await userService.RetrieveAllUsersAsync();
        var user = users.FirstOrDefault(u => u.Username == username);

        if (user is null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
            throw new Exception("Invalid credentials");

        string token = GenerateJwtToken(user);

        return new AuthResponse (token,user);
    }

    private string GenerateJwtToken(User user)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Username),
            new Claim("id", user.Id.ToString())
        };

        var token = new JwtSecurityToken(
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddDays(7),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}