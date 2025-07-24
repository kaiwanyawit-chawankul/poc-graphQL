public interface IOrderApiClient
{
    Task<Order> GetOrderByIdAsync(int id);
    Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId);
    Task<Order> CreateOrderAsync(Order order);
}


public class OrderApiClient : IOrderApiClient
{
    private readonly HttpClient _httpClient;

    public OrderApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Order> CreateOrderAsync(Order order)
    {
        var response = await _httpClient.PostAsJsonAsync("/api/orders", order);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<Order>();
        }
        throw new NotImplementedException();
    }

    public async Task<Order> GetOrderByIdAsync(int id)
    {
        var response = await _httpClient.GetFromJsonAsync<Order>($"/api/orders/{id}");
        return response!;
    }

    public Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId)
    {
        var response = _httpClient.GetFromJsonAsync<IEnumerable<Order>>($"/api/users/{userId}/orders");
        return response!;
    }
}
