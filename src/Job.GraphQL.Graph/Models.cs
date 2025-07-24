public class Book
{
    public string Title { get; set; }

    public Author Author { get; set; }
}

public class Author
{
    public string Name { get; set; }
}

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}

public class Order
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Product { get; set; }
    public int Quantity { get; set; }
}
