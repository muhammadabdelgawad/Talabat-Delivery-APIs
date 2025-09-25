# Talabat Delivery APIs

This repository contains the source code for the Talabat Delivery APIs, a set of RESTful APIs designed to manage products, categories, brands, and customer baskets.

## Features and Functionality

The Talabat Delivery APIs provide the following functionalities:

*   **Product Management:**
    *   Retrieve a paginated list of products with filtering and sorting options.
    *   Retrieve a specific product by ID.
    *   Retrieve a list of product brands.
    *   Retrieve a list of product categories.
*   **Basket Management:**
    *   Retrieve a customer's basket by ID.
    *   Update a customer's basket.
    *   Delete a customer's basket.
*   **Error Handling:**
    *   Comprehensive error handling with custom API response formats.
    *   Buggy endpoints to simulate various error scenarios for testing purposes.
*   **Identity and Authorization:**
    *   User authentication and authorization using ASP.NET Core Identity.
    *   Configurable password policies.
    *   Email confirmation and account lockout features.
*   **Database Initialization:**
    *   Automatic database migration and seeding.

## Technology Stack

*   **ASP.NET Core:** Web framework for building the APIs.
*   **C#:** Programming language.
*   **Entity Framework Core (EF Core):** Object-Relational Mapper (ORM) for database interactions.
*   **SQL Server:** Relational database for storing product and identity data.
*   **Redis:** In-memory data store for managing customer baskets.
*   **AutoMapper:** Object-object mapper for DTO transformations.
*   **Swagger:** API documentation and testing.
*   **.NET 9.0:** Runtime environment

## Prerequisites

Before running the Talabat Delivery APIs, ensure you have the following installed:

*   **.NET SDK 9.0:** Download and install the .NET SDK from the official Microsoft website.
*   **SQL Server:** Install SQL Server and SQL Server Management Studio (SSMS).
*   **Redis:** Install a local Redis server or have access to a Redis instance.

## Installation Instructions

1.  **Clone the repository:**

    ```bash
    git clone https://github.com/muhammadabdelgawad/Talabat-Delivery-APIs.git
    cd Talabat-Delivery-APIs
    ```

2.  **Update Connection Strings:**
    Modify the connection strings in `Talabat.APIs/appsettings.json` for `StoreConnection` and `IdentityConnection` to point to your SQL Server instance. Also configure Redis Connection string.

    ```json
    {
      "ConnectionStrings": {
        "StoreConnection": "Server=your_server;Database=TalabatStoreDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True",
        "IdentityConnection": "Server=your_server;Database=TalabatIdentityDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True",
        "Redis": "localhost"
      },
        "RedisSettings": {
            "TimeToLiveInDays": "30"
        },
        "Urls": {
            "ApiBaseUrl": "https://localhost:7219/"
        }
    }
    ```

3.  **Apply Database Migrations:**

    Open a terminal in the `Talabat.APIs` directory and run the following commands:

    ```bash
    dotnet ef database update -p ../Talabat.Infrastructure.Persistence -s Talabat.APIs
    dotnet ef database update -p ../Talabat.Infrastructure.Persistence -c StoreIdentityDbConetxt  -s Talabat.APIs
    ```

    These commands will create the databases and apply the latest migrations.

## Usage Guide

1.  **Run the application:**

    Open a terminal in the `Talabat.APIs` directory and run the following command:

    ```bash
    dotnet run
    ```

    This will start the API server.

2.  **Access the API endpoints:**

    The API endpoints can be accessed via HTTP requests. You can use tools like Postman or Swagger UI to interact with the APIs.

    *   **Swagger UI:** Navigate to `https://localhost:<port>/swagger` in your browser to access the Swagger UI. Replace `<port>` with the port number your application is running on (typically 5001 for HTTPS).

## API Documentation

### Products API

*   **GET /api/Products:** Retrieves a paginated list of products.
    *   **Query Parameters:**
        *   `sort`: Sort order (e.g., `priceAsc`, `priceDesc`).
        *   `brandId`: Filter by brand ID.
        *   `categoryId`: Filter by category ID.
        *   `pageIndex`: Page number (default: 1).
        *   `pageSize`: Number of items per page (default: 10, max: 100).
        *    `search`: Search term

    *   **Response:**
        ```json
        {
          "pageIndex": 1,
          "pageSize": 10,
          "count": 100,
          "data": [
            {
              "id": 1,
              "name": "Product Name",
              "description": "Product Description",
              "pictureUrl": "https://localhost:7219//images/products/sb-ang1.png",
              "price": 19.99,
              "brandId": 1,
              "brand": "Brand Name",
              "categoryId": 1,
              "category": "Category Name"
            }
          ]
        }
        ```

*   **GET /api/Products/{id}:** Retrieves a product by ID.
    *   **Response:**
        ```json
        {
          "id": 1,
          "name": "Product Name",
          "description": "Product Description",
          "pictureUrl": "https://localhost:7219//images/products/sb-ang1.png",
          "price": 19.99,
          "brandId": 1,
          "brand": "Brand Name",
          "categoryId": 1,
          "category": "Category Name"
        }
        ```
*   **GET /api/Products/brands:** Retrieves all brands
    *   **Response:**
        ```json
         [
            {
                "id": 1,
                "name": "Addidas"
            },
            {
                "id": 2,
                "name": "Nike"
            }
        ]
        ```
*   **GET /api/Products/categories:** Retrieves all categories
     *   **Response:**
        ```json
          [
            {
                "id": 1,
                "name": "Shoes"
            },
            {
                "id": 2,
                "name": "Bags"
            }
        ]
        ```

### Basket API

*   **GET /api/Basket/{id}:** Retrieves a customer's basket by ID.
    *   **Response:**
        ```json
        {
          "id": "customer123",
          "items": [
            {
              "id": 1,
              "productName": "Product Name",
              "pictureUrl": "string",
              "price": 19.99,
              "quantity": 1,
              "brand": "string",
              "category": "string"
            }
          ]
        }
        ```

*   **POST /api/Basket:** Updates a customer's basket.
    *   **Request Body:**
        ```json
        {
          "id": "customer123",
          "items": [
            {
              "id": 1,
              "productName": "Product Name",
              "pictureUrl": "string",
              "price": 19.99,
              "quantity": 2,
              "brand": "string",
              "category": "string"
            }
          ]
        }
        ```

    *   **Response:**
        ```json
        {
          "id": "customer123",
          "items": [
            {
              "id": 1,
              "productName": "Product Name",
              "pictureUrl": "string",
              "price": 19.99,
              "quantity": 2,
              "brand": "string",
              "category": "string"
            }
          ]
        }
        ```

*   **DELETE /api/Basket/{id}:** Deletes a customer's basket.
    *   **Response:** 204 No Content

### Buggy API

*   **GET /api/Buggy/not-found:** Returns a 404 Not Found error.
*   **GET /api/Buggy/server-error:** Returns a 500 Server Error.
*   **GET /api/Buggy/bad-request:** Returns a 400 Bad Request error.
*   **GET /api/Buggy/unauthorized:** Returns a 401 Unauthorized error. Requires authentication.
*   **GET /api/Buggy/forbidden:** Returns a 403 Forbidden error.

## Contributing Guidelines

Contributions to the Talabat Delivery APIs are welcome. Please follow these guidelines:

1.  Fork the repository.
2.  Create a new branch for your feature or bug fix.
3.  Implement your changes.
4.  Write unit tests for your changes.
5.  Submit a pull request.

## License Information

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

