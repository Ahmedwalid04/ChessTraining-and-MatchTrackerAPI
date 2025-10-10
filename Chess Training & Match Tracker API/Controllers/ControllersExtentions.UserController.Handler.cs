using ChessTrainingApi.Models;
using ChessTrainingApi.Services;
namespace ChessTrainingApi.Controllers;
public partial class ControllersExtentions
{
    static async ValueTask<IResult> PostUserAsync(IUserServices userService, User user)
    {
        if (user == null)
        {
            return Results.BadRequest();
        }
        await userService.AddUserAsync(user);
        return Results.Created($"/users/{user.Id}", user);
    }
    static async ValueTask<IResult> PutUserAsync(IUserServices userService, int userId, User user)
    {
        if (user == null || user.Id != userId)
        {
            return Results.BadRequest();
        }
        var existingUser = await userService.RetrieveUserByIdAsync(userId);
        if (existingUser is null)
        {
            return Results.NotFound();
        }
        await userService.ModifyUserAsync(user);
        return Results.NoContent();
    }
    static async ValueTask<IResult> GetAllUsersAsync(IUserServices userService)
    {
        var users = await userService.RetrieveAllUsersAsync();
        return Results.Ok(users);
    }
    static async ValueTask<IResult> GetUserByIdAsync(IUserServices userService, int userId)
    {
        var user = await userService.RetrieveUserByIdAsync(userId);
        return user is not null ? Results.Ok(user) : Results.NotFound();
    }
    static async ValueTask<IResult> DeleteUserByIdAsync(IUserServices userService, int userId)
    {
        var user = await userService.RetrieveUserByIdAsync(userId);
        if (user is null)
        {
            return Results.NotFound();
        }
        await userService.RemoveUserByIdAsync(userId);
        return Results.NoContent();
    }
}