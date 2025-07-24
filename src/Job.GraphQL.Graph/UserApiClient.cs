public interface IUserApiClient
{
    Task<User> GetUserByIdAsync(int id);
}


public class UserApiClient : IUserApiClient
{
    private readonly HttpClient _httpClient;

    public UserApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
        var response = await _httpClient.GetFromJsonAsync<User>($"/api/users/{id}");
        return response!;
    }
}
