var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Hello World!");

app.MapGet("/time/utc", () => DateTime.UtcNow);
app.MapGet("/time/local", () => DateTime.Now);

app.MapPost("/add-user", (App.UserInput user) => {
    return $"User {user.Name} with email {user.Email} added";
});

app.Run();


namespace App {
    public record UserInput(string Name, string Email);
}