using wt_lab6_6minimalapi_lyashuk.Data;
using wt_lab6_6minimalapi_lyashuk.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Блок 1: Проверка работы и информация
app.MapGet("/", () => "Minimal API работает!");

app.MapGet("/api/info", () => new
{
    Application = "Esport Tournament Manager API",
    Technology = "ASP.NET Core Minimal API",
    Version = "1.0",
    Author = "Lyashuk Vladislav"
});

// Блок 3: GET эндпоинты (список, фильтрация, по ID)
app.MapGet("/api/products", (string? search) =>
{
    var players = PlayerStore.Players.AsEnumerable();

    if (!string.IsNullOrWhiteSpace(search))
    {
        players = players.Where(p => p.Nickname.Contains(search, StringComparison.OrdinalIgnoreCase));
    }

    return Results.Ok(players);
});

app.MapGet("/api/products/{id}", (int id) =>
{
    var player = PlayerStore.Players.FirstOrDefault(p => p.Id == id);
    if (player == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(player);
});

// Блок 4: POST эндпоинт
app.MapPost("/api/products", (Player product) =>
{
    var newId = PlayerStore.Players.Count == 0
        ? 1
        : PlayerStore.Players.Max(x => x.Id) + 1;

    product.Id = newId;
    PlayerStore.Players.Add(product);

    return Results.Created($"/api/products/{product.Id}", product);
});

// Блок 5.1: PUT эндпоинт
app.MapPut("/api/products/{id}", (int id, Player updatedProduct) =>
{
    var player = PlayerStore.Players.FirstOrDefault(x => x.Id == id);
    if (player == null)
    {
        return Results.NotFound();
    }

    player.Nickname = updatedProduct.Nickname;
    player.Role = updatedProduct.Role;
    player.Rating = updatedProduct.Rating;
    player.IsActive = updatedProduct.IsActive;

    return Results.Ok(player);
});

// Блок 5.2: DELETE эндпоинт
app.MapDelete("/api/products/{id}", (int id) =>
{
    var player = PlayerStore.Players.FirstOrDefault(x => x.Id == id);
    if (player == null)
    {
        return Results.NotFound();
    }

    PlayerStore.Players.Remove(player);
    return Results.NoContent();
});

// Блок 10.2: Настройка порта для Render
var port = Environment.GetEnvironmentVariable("PORT") ?? "10000";
app.Run($"http://0.0.0.0:{port}");