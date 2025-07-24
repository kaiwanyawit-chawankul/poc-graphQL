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
}
