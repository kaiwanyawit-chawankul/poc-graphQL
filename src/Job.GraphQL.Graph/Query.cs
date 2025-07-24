public class Query
{
    public Book GetBook() =>
        new Book
        {
            Title = "C# in depth.",
            Author = new Author
            {
                Name = "Jon Skeet"
            }
        };

    public async Task<User> GetUser(int id, [Service] IUserApiClient userApiClient)
    {
        return await userApiClient.GetUserByIdAsync(id);
    }

    public async Task<Order> GetOrder(int id, [Service] IOrderApiClient orderApiClient)
    {
        return await orderApiClient.GetOrderByIdAsync(id);
    }

    public async Task<IEnumerable<Order>> GetOrdersByUserId(int userId, [Service] IOrderApiClient orderApiClient)
    {
        return await orderApiClient.GetOrdersByUserIdAsync(userId);
    }
}
