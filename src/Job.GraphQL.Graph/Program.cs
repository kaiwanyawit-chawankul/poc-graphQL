using HotChocolate.AspNetCore;
using HotChocolate;
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddHttpClient<IUserApiClient, UserApiClient>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5101"); // or your internal URL
});

builder.Services.AddHttpClient<IOrderApiClient, OrderApiClient>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5102"); // or your internal URL
});

var app = builder.Build();
app.MapGraphQL();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();
