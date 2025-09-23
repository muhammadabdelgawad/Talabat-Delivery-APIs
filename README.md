# Talabat Delivery APIs

## Project Description

This repository contains the source code for a set of APIs designed to manage various aspects of a Talabat-like delivery platform. It includes functionalities for handling product catalogs, customer baskets, and error management.

## Features and Functionality

*   **Product Management:**
    *   Retrieve a paginated list of products with filtering, sorting, and searching capabilities.  Uses `ProductSpecParams` for specifying parameters.  Implemented in `Talabat.APIs.Controllers/Controllers/Products/ProductsController.cs`.
    *   Fetch a specific product by its ID.
    *   Get a list of product brands and categories.
*   **Basket Management:**
    *   Retrieve, update, and delete customer baskets.  Uses `BasketDto` for data transfer. Implemented in `Talabat.APIs.Controllers/Basket/BasketController.cs`.
*   **Error Handling:**
    *   Comprehensive error handling using custom exception middleware (`Talabat.APIs/Middlewares/ExceptionHandlerMiddleware.cs`) and API response structures (`Talabat.APIs.Controllers/Errors/ApiResponse.cs`).
    *   Specific error routes for common HTTP status codes (400, 401, 404, 500).
*   **Buggy Controller:**  A dedicated controller (`Talabat.APIs.Controllers/Controllers/Buggy/BuggyController.cs`) to simulate and test various error scenarios (Not Found, Server Error, Bad Request, Unauthorized, Forbidden).
*   **Model Validation:** API behaviour configured to suppress model state invalid filter by default, which will generate error messages as per `ApiValidationErrorResponse` model.

## Technology Stack

*   **.NET:**  ASP.NET Core Web API
*   **Entity Framework Core:**  ORM for database interactions
*   **SQL Server:**  Relational database
*   **Redis:**  In-memory data store for basket management
*   **AutoMapper:**  Object-object mapper
*   **StackExchange.Redis:** Redis client for .NET
*   **Swashbuckle/Swagger:** API documentation and testing

## Prerequisites

Before you can run this project, ensure you have the following installed:

*   **.NET SDK:** .NET 9.0 or higher.
*   **SQL Server:**  A running instance of SQL Server.
*   **Redis Server:** A running instance of Redis server.
*   **IDE:**  Visual Studio or Visual Studio Code (recommended)

## Installation Instructions

1.  **Clone the repository:**

    ```bash
    git clone https://github.com/muhammadabdelgawad/Talabat-Delivery-APIs.git
    cd Talabat-Delivery-APIs
    ```

2.  **Configure the database connection string:**

    *   Open `Talabat.Infrastructure.Persistence/DependencyInjection.cs` and locate the following code:

    ```csharp
                 options.UseLazyLoadingProxies()
                         .UseSqlServer(configuration.GetConnectionString("StoreConnection"))
    ```

    *   Modify the `"StoreConnection"` connection string in `appsettings.json` (or `appsettings.Development.json`) to point to your SQL Server instance.  Example:

    ```json
    {
      "ConnectionStrings": {
        "StoreConnection": "Data Source=YourServerName;Initial Catalog=TalabatStoreDB;Integrated Security=True;TrustServerCertificate=True"
      },
    }
    ```
   * **Configure the Redis Connection String:**
      * Modify the `"Redis"` connection string in `appsettings.json` (or `appsettings.Development.json`) to point to your Redis server instance. Example:
    ```json
     "ConnectionStrings": {
        "Redis": "localhost"
      },
    ```
    *Configure the `Urls:ApiBaseUrl` in `appsettings.json` (or `appsettings.Development.json`) with the api base url.

    ```json
      "Urls": {
        "ApiBaseUrl": "https://localhost:7239"
      }
    ```

3.  **Apply database migrations:**

    ```bash
    cd Talabat.Infrastructure.Persistence
    dotnet ef database update -s ../Talabat.APIs
    ```

4.  **Run the application:**

    ```bash
    cd Talabat.APIs
    dotnet run
    ```

## Usage Guide

The API endpoints can be accessed through any HTTP client (e.g., Postman, Insomnia, or a web browser).

### Product API

*   **Get all products:**

    ```
    GET /api/Products?sort=priceAsc&brandId=1&categoryId=2&pageIndex=1&pageSize=5&search=Product Name
    ```

    *   `sort`: Sorting options (`priceAsc`, `priceDesc`, or default by name).
    *   `brandId`: Filter by brand ID.
    *   `categoryId`: Filter by category ID.
    *   `pageIndex`: Page number.
    *   `pageSize`: Number of products per page.
    *   `search`: Search term.

*   **Get a product by ID:**

    ```
    GET /api/Products/{id}
    ```

*   **Get all brands:**

    ```
    GET /api/Products/brands
    ```

*   **Get all categories:**

    ```
    GET /api/Products/categories
    ```

### Basket API

*   **Get basket by ID:**

    ```
    GET /api/Basket/{id}
    ```

*   **Update basket:**

    ```
    POST /api/Basket
    ```

    *   Request body (JSON):

    ```json
    {
      "id": "basketId",
      "items": [
        {
          "id": 1,
          "productName": "Product 1",
          "pictureUrl": "image1.jpg",
          "price": 10.99,
          "quantity": 2,
          "brand": "BrandA",
          "category": "CategoryX"
        }
      ]
    }
    ```

*   **Delete basket:**

    ```
    DELETE /api/Basket/{id}
    ```

### Error Handling

The API returns standard HTTP status codes and JSON responses for errors. For example, a "Not Found" error will return a 404 status code and a JSON body like this:

```json
{
  "statusCode": 404,
  "message": "Resource found, it was not"
}
```

In development, exception details are included in the API response.

## API Documentation

Swagger documentation is enabled in the development environment. Access it by navigating to `/swagger` in your browser after running the application. For example: `https://localhost:7239/swagger`

## Contributing Guidelines

Contributions are welcome! To contribute to this project, follow these steps:

1.  Fork the repository.
2.  Create a new branch for your feature or bug fix.
3.  Implement your changes.
4.  Test your changes thoroughly.
5.  Submit a pull request.

## License Information

This project is licensed under the MIT License. See the `LICENSE` file for more details.
