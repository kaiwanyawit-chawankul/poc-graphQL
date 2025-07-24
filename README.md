# Job.GraphQL

This solution contains two web API projects: **Job.GraphQL.Users** and **Job.GraphQL.Orders**.

## Projects

### Job.GraphQL.Users
This project handles user-related operations. It includes:
- **Controllers/UsersController.cs**: Manages HTTP requests for users.
- **Models/User.cs**: Defines the User model with properties like Id, Name, and Email.
- **Program.cs**: Entry point for the Users API.
- **Startup.cs**: Configures services and the request pipeline.
- **Job.GraphQL.Users.csproj**: Project file with dependencies and build settings.

### Job.GraphQL.Orders
This project manages order-related operations. It includes:
- **Controllers/OrdersController.cs**: Manages HTTP requests for orders.
- **Models/Order.cs**: Defines the Order model with properties like Id, UserId, Product, and Quantity.
- **Program.cs**: Entry point for the Orders API.
- **Startup.cs**: Configures services and the request pipeline.
- **Job.GraphQL.Orders.csproj**: Project file with dependencies and build settings.

## Setup Instructions
1. Clone the repository.
2. Navigate to the solution directory.
3. Restore the NuGet packages:
   ```
   dotnet restore
   ```
4. Run the solution:
   ```
   dotnet run
   ```

## Usage
- Access the Users API at `http://localhost:<port>/api/users`
- Access the Orders API at `http://localhost:<port>/api/orders`

## Contributing
Feel free to submit issues or pull requests for improvements or bug fixes.


## References
https://chillicream.com/docs/hotchocolate/v13/get-started-with-graphql-in-net-core
https://chillicream.com/docs/hotchocolate/v13/fetching-data/fetching-from-rest
https://github.com/ChilliCream/graphql-workshop/blob/main/docs/1-creating-a-graphql-server-project.md

## Usage

http://localhost:5290/graphql/

```
{
  book {
    title
    author {
      name
    }
  }
}
```

```
{
  user(id: 50) {
    id
    name
    email
  }
}
```