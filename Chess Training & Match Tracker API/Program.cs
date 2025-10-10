using ChessTrainingApi.Services;
using ChessTrainingApi.Brokers;
using Scalar.AspNetCore;
using ChessTrainingApi.Controllers;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi();
builder.Services.AddScoped<IStorageBroker, StorageBroker>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IPuzzleServices, PuzzleServices>();
builder.Services.AddScoped<IMatchServices, MatchServices>();
builder.Services.AddScoped<ITrainingPlanServices, TrainingPlanServices>();
builder.Services.AddScoped<IAuthServices, AuthServices>();
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

builder.Services.AddAuthorization();


var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapUserController().MapTrainingPlanController()
.MapPuzzleController().MapMatchController().MapAuthController(); 

app.MapOpenApi();

app.MapScalarApiReference(options =>
{
    options
        .WithTitle("Simple API")
        .WithTheme(ScalarTheme.Default)
        .WithDarkModeToggle(false)
        .WithDefaultHttpClient(ScalarTarget.JavaScript, ScalarClient.Axios);

});

app.Run();
