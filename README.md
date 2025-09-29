# Talabat Delivery APIs

This repository contains the backend APIs for a Talabat-like delivery application. It provides endpoints for managing products, user accounts, and shopping baskets.

## Features and Functionality

*   **Product Management:**
    *   Retrieve a paginated list of products with filtering, sorting, and searching.
    *   Fetch a specific product by ID.
    *   Get a list of available product brands.
    *   Get a list of available product categories.
*   **User Account Management:**
    *   Register a new user account.
    *   Log in an existing user.
    *   Retrieve the current user's information (requires authentication).
    *   Get the user's address (requires authentication).
    *   Update the user's address (requires authentication).
    *   Check if an email address already exists.
*   **Shopping Basket Management:**
    *   Retrieve a customer's shopping basket by ID.
    *   Update a customer's shopping basket.
    *   Delete a customer's shopping basket.
*   **Error Handling:**
    *   Comprehensive error handling middleware to return standardized API responses for common errors such as:
        *   400 Bad Request
        *   401 Unauthorized
        *   404 Not Found
        *   500 Server Error
        *   Validation Errors

## Technology Stack

*   **ASP.NET Core:**  The backend is built using ASP.NET Core.
*   **C#:** The primary programming language.
*   **Entity Framework Core:** Used for database interaction.
*   **SQL Server:** The relational database used for storing product and user data. Connection string is configured in `appsettings.json`.
*   **Redis:** Used for storing shopping basket data. Connection string is configured in `appsettings.json`.
*   **AutoMapper:**  Used for object-to-object mapping between domain entities and DTOs.
*   **Microsoft Identity:** Used for Authentication and Authorization.
*   **JWT (JSON Web Tokens):**  Used for user authentication and authorization. JWT settings are configured in the `appsettings.json` file under the `jwtSettings` section.
*   **StackExchange.Redis:** Redis client library used to interact with Redis server.

## Prerequisites

Before you begin, ensure you have met the following requirements:

*   **.NET SDK:**  Install the .NET SDK (version 8.0 or later).  Download it from [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download).
*   **SQL Server:** Install SQL Server. You can use SQL Server Express for development.
*   **Redis:** Install Redis server.
*   **IDE/Text Editor:**  Visual Studio, Visual Studio Code, or any other suitable C# IDE or text editor.

## Installation Instructions

1.  **Clone the Repository:**

    ```bash
    git clone https://github.com/muhammadabdelgawad/Talabat-Delivery-APIs.git
    cd Talabat-Delivery-APIs
    ```

2.  **Update Database Connection Strings:**

    *   Open the `Talabat.APIs/appsettings.json` file.
    *   Modify the `StoreConnection` and `IdentityConnection` connection strings to point to your SQL Server instance.  For example:

    ```json
    "ConnectionStrings": {
      "StoreConnection": "Server=your_server;Database=TalabatStoreDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True",
      "IdentityConnection": "Server=your_server;Database=TalabatIdentityDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True",
      "Redis": "localhost"
    }
    ```

    *   Modify the `Redis` connection string to point to your Redis instance.

3.  **Apply Database Migrations:**

    *   Open a terminal in the `Talabat.Infrastructure.Persistence` directory.
    *   Run the following commands to apply the EF Core migrations:

    ```bash
    dotnet ef database update -c StoreDbContext
    dotnet ef database update -c StoreIdentityDbConetxt
    ```

4.  **Run the Application:**

    *   Open a terminal in the `Talabat.APIs` directory.
    *   Run the following command to start the application:

    ```bash
    dotnet run
    ```

    The API will be accessible at `https://localhost:{port}` (the port number will be displayed in the console).

## Usage Guide

After running the application, you can access the API endpoints using tools like Postman, Swagger UI (if enabled), or by integrating them into a client application.

### API Endpoints

Here are some of the key API endpoints:

*   **Authentication**
    *   `POST api/Account/register`: Registers a new user.
        *   Request body: `RegisterDto` (`DisplayName`, `UserName`, `Email`, `PhoneNumber`, `Password`)
        *   Response body: `UserDto` (`Id`, `DisplayName`, `Email`, `Token`)

    *   `POST api/Account/login`: Logs in an existing user.
        *   Request body: `LoginDto` (`Email`, `Password`)
        *   Response body: `UserDto` (`Id`, `DisplayName`, `Email`, `Token`)

    *   `GET api/Account`: Gets the current user (requires authentication).
        *   Response body: `UserDto` (`Id`, `DisplayName`, `Email`, `Token`)

    *   `GET api/Account/address`: Gets the user's address (requires authentication).
        *   Response body: `AddressDto` (`FirstName`, `LastName`, `Street`, `City`, `Country`)

    *   `PUT api/Account/address`: Updates the user's address (requires authentication).
        *   Request body: `AddressDto` (`FirstName`, `LastName`, `Street`, `City`, `Country`)

    *    `GET api/Account/emailexisits?email={email}`: Checks if the email exists.

*   **Products**

    *   `GET api/Products`: Gets a paginated list of products.
        *   Query parameters:
            *   `sort`: Sorting order (e.g., `priceAsc`, `priceDesc`).
            *   `brandId`: Filter by brand ID.
            *   `categoryId`: Filter by category ID.
            *   `pageIndex`: Page number.
            *   `pageSize`: Number of items per page.
            *    `search`: Search term for product name.
        *   Response body: `Pagination<ProductToReturnDto>`

    *   `GET api/Products/{id}`: Gets a specific product by ID.
        *   Response body: `ProductToReturnDto`

    *   `GET api/Products/brands`: Gets a list of product brands.
        *   Response body: `IEnumerable<BrandDto>`

    *   `GET api/Products/categories`: Gets a list of product categories.
        *   Response body: `IEnumerable<CategoryDto>`

*   **Basket**

    *   `GET api/Basket?id={id}`: Gets a customer's basket.
        *   Response body: `BasketDto` (`Id`, `Items` where `Items` is a list of `BasketItemDto`)

    *   `POST api/Basket`: Updates a customer's basket.
        *   Request body: `BasketDto` (`Id`, `Items` where `Items` is a list of `BasketItemDto`)
        *   Response body: `BasketDto` (`Id`, `Items` where `Items` is a list of `BasketItemDto`)

    *   `DELETE api/Basket?id={id}`: Deletes a customer's basket.

*   **Buggy (for testing error handling)**
    *  `GET api/Buggy/not-found`: Simulates a 404 Not Found error.
    *  `GET api/Buggy/server-error`: Simulates a 500 Server Error.
    *  `GET api/Buggy/bad-request`: Simulates a 400 Bad Request error.
    *  `GET api/Buggy/bad-request/{id}`: Simulates a validation error.
    *  `GET api/Buggy/unauthorized`: Simulates a 401 Unauthorized error (requires authentication).
    *  `GET api/Buggy/forbidden`: Simulates a 403 Forbidden error.

*   **Errors**

    *   `GET Errors/{Code}`: Generic endpoint for displaying error information based on HTTP status code.

### Authentication

Some endpoints require authentication. To access these endpoints, you'll need to include an `Authorization` header in your request with a valid JWT token.  You can obtain a JWT token by registering a user or logging in.

Example `Authorization` header:

```
Authorization: Bearer <your_jwt_token>
```

## API Documentation

Swagger UI is enabled for development environments.  To access it, navigate to `https://localhost:{port}/swagger` in your browser when the application is running.  This provides interactive API documentation and allows you to test the endpoints.

## Contributing Guidelines

Contributions are welcome! To contribute to this project, follow these steps:

1.  Fork the repository.
2.  Create a new branch for your feature or bug fix.
3.  Implement your changes.
4.  Write tests for your changes.
5.  Ensure all tests pass.
6.  Submit a pull request.

