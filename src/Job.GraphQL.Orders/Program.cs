using System.Collections.Concurrent;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// In-memory order store
var ordersStore = new ConcurrentDictionary<int, dynamic>();
var orderIdCounter = 1000;

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/api/orders/{id}", (int id) =>
{
    // Try to get from in-memory store first
    if (ordersStore.TryGetValue(id, out var storedOrder))
        return Results.Ok(storedOrder);

    return Results.NotFound(id);
})
.WithName("GetOrderById");

app.MapGet("/api/users/{userId}/orders", (int userId) =>
{
    // Combine in-memory orders and mock orders
    var inMemoryOrders = ordersStore.Values.Where(o => o.UserId == userId);
    var allOrders = inMemoryOrders;
    return Results.Ok(allOrders);
})
.WithName("GetOrdersByUserId");

// Create new order endpoint
app.MapPost("/api/orders", (OrderDto orderDto) =>
{
    var id = Interlocked.Increment(ref orderIdCounter);
    var order = new
    {
        Id = id,
        UserId = orderDto.UserId,
        Product = orderDto.Product,
        Quantity = orderDto.Quantity
    };
    ordersStore[id] = order;
    return Results.Created($"/api/orders/{id}", order);
})
.WithName("CreateOrder");

app.Run();
public record OrderDto(int UserId, string Product, int Quantity);
