var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/test", async (HttpRequest request) =>
{
    app.Logger.LogInformation("[{}] Logger is working! Path: {}", DateTime.UtcNow, request.Path);

    var responseDto = new
    {
        Message = $"API is working! Path: {request.Path}",
        Date = DateTime.UtcNow,
        DotnetVersion = Environment.Version,
    };

    return Results.Ok(await Task.FromResult(responseDto));
})
.WithName("ApiTest")
.WithOpenApi();

app.Run();
