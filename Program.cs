using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/health", () =>
    Results.Ok(new { Status = "Healthy", Time = System.DateTime.UtcNow })
    );

app.Run();
