using ChessTrainingApi.Models;
using ChessTrainingApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;

namespace ChessTrainingApi.Controllers;

public partial class ControllersExtentions
{
    static async ValueTask<IResult> RegisterAsync(IAuthServices authService, User user)
    {
        if (user is null)
            return Results.BadRequest("User data is required.");

        var createdUser = await authService.RegisterAsync(user);
        return Results.Created($"/users/{createdUser.Id}", createdUser);
    }

    static async ValueTask<IResult> LoginAsync(IAuthServices authService, Models.LoginRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
            return Results.BadRequest("Username and password are required.");

        try
        {
            var response = await authService.LoginAsync(request.Username, request.Password);
            return Results.Ok(response);
        }
        catch (Exception ex)
        {
            return Results.BadRequest(new { error = ex.Message });
        }
    }

}
