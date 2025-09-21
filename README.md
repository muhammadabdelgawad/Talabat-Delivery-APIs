# Talabat Delivery APIs

## Description

This repository contains the backend APIs for the Talabat Delivery application. It provides endpoints for managing products, brands, categories, and handling common errors. The APIs are built using ASP.NET Core and follow a layered architecture with Domain, Application, and Infrastructure layers.

## Features and Functionality

*   **Product Management:**
    *   Retrieve a paginated list of products with filtering, sorting, and searching capabilities.
    *   Retrieve a specific product by its ID.
    *   Retrieve a list of product brands.
    *   Retrieve a list of product categories.
*   **Error Handling:**
    *   Global exception handling middleware to catch and log unhandled exceptions.
    *   Custom error responses for common HTTP status codes (400, 401, 404, 500).
    *   Endpoint for simulating common errors (e.g., Not Found, Server Error, Bad Request).
*   **API Versioning:** (Implicit through controller routing - "api/[controller]")
*   **Database Initialization and Seeding:** Ensures the database is created and seeded with initial data.

## Technology Stack

*   **ASP.NET Core:** Web framework for building the APIs.
*   **Entity Framework Core:** ORM for interacting with the database.
*   **SQL Server:** Database used for storing application data.
*   **AutoMapper:** Object-relational mapper to map domain entities to DTOs.
*   **.NET 8:** The .NET version that this project is based on.

## Prerequisites

*   .NET 8 SDK or later.
*   SQL Server instance.
*   An IDE or text editor (e.g., Visual Studio, VS Code).

## Installation Instructions

1.  **Clone the repository:**

    ```bash
    git clone https://github.com/muhammadabdelgawad/Talabat-Delivery-APIs.git
    cd Talabat-Delivery-APIs
    ```

2.  **Configure the database connection string:**

    *   Open the `Talabat.APIs/appsettings.json` file.
    *   Modify the `StoreConnection` connection string to point to your SQL Server instance. Example:

    ```json
    {
      "ConnectionStrings": {
        "StoreConnection": "Data Source=your_server;Initial Catalog=TalabatStore;Integrated Security=True;TrustServerCertificate=true"
      },
      "Urls": {
        "ApiBaseUrl": "https://localhost:7227/"
      }
    }
    ```

    *   Ensure your SQL Server instance has the proper credentials for connecting.

3.  **Apply database migrations:**

    *   Navigate to the `Talabat.APIs` directory in the command line.
    *   Run the following command to create the database and apply migrations:

    ```bash
    dotnet ef database update --project ../Talabat.Infrastructure.Persistence --startup-project ./
    ```

    This command uses the Entity Framework Core tools to apply the migrations defined in the `Talabat.Infrastructure.Persistence` project to your database.

4.  **Build the project:**

    ```bash
    dotnet build Talabat.APIs/Talabat.APIs.csproj
    ```

5.  **Run the project:**

    ```bash
    dotnet run --project Talabat.APIs/Talabat.APIs.csproj
    ```

## Usage Guide

Once the application is running, you can access the APIs through your browser or any API client (e.g., Postman, Insomnia).

### Endpoints

#### Products

*   **GET /api/Products:** Retrieves a paginated list of products.
    *   Query Parameters:
        *   `sort`: Sort order (e.g., "priceAsc", "priceDesc").
        *   `brandId`: Filter by brand ID.
        *   `categoryId`: Filter by category ID.
        *   `pageIndex`: Page number (default: 1).
        *   `pageSize`: Number of products per page (default: 10, max: 100).
        *   `search`: Search term for product names.
    *   Example: `/api/Products?sort=priceDesc&brandId=1&pageIndex=2&pageSize=20`

*   **GET /api/Products/{id}:** Retrieves a specific product by its ID.
    *   Example: `/api/Products/1`

*   **GET /api/Products/brands:** Retrieves a list of product brands.

*   **GET /api/Products/categories:** Retrieves a list of product categories.

#### Buggy

*   **GET /api/Buggy/not-found:** Returns a 404 Not Found error.
*   **GET /api/Buggy/server-error:** Throws an exception to simulate a server error.
*   **GET /api/Buggy/bad-request:** Returns a 400 Bad Request error.
*   **GET /api/Buggy/bad-request/{id}:** Returns a 200 OK.
*   **GET /api/Buggy/unauthorized:** Returns a 401 Unauthorized error. Requires authentication.
*   **GET /api/Buggy/forbidden:** Returns a 403 Forbidden error.

#### Errors

*   **GET /Errors/{code}:** Returns a custom error response based on the provided HTTP status code.

### Example Request (Get Products)

```
GET https://localhost:7227/api/Products?pageIndex=1&pageSize=5&sort=priceAsc
```

### Example Response (Get Products)

```json
{
  "pageIndex": 1,
  "pageSize": 5,
  "count": 21,
  "data": [
    {
      "id": 1,
      "name": "Product 1",
      "description": "Description of Product 1",
      "pictureUrl": "https://localhost:7227//images/products/sb-ang1.png",
      "price": 18,
      "brandId": 1,
      "brand": "Brand 1",
      "categoryId": 1,
      "category": "Category 1"
    },
    {
      "id": 2,
      "name": "Product 2",
      "description": "Description of Product 2",
      "pictureUrl": "https://localhost:7227//images/products/sb-ang2.png",
      "price": 19,
      "brandId": 2,
      "brand": "Brand 2",
      "categoryId": 2,
      "category": "Category 2"
    },
    {
      "id": 3,
      "name": "Product 3",
      "description": "Description of Product 3",
      "pictureUrl": "https://localhost:7227//images/products/sb-ang3.png",
      "price": 20,
      "brandId": 3,
      "brand": "Brand 3",
      "categoryId": 3,
      "category": "Category 3"
    },
    {
      "id": 4,
      "name": "Product 4",
      "description": "Description of Product 4",
      "pictureUrl": "https://localhost:7227//images/products/sb-core1.png",
      "price": 21,
      "brandId": 4,
      "brand": "Brand 4",
      "categoryId": 4,
      "category": "Category 4"
    },
    {
      "id": 5,
      "name": "Product 5",
      "description": "Description of Product 5",
      "pictureUrl": "https://localhost:7227//images/products/sb-core2.png",
      "price": 22,
      "brandId": 5,
      "brand": "Brand 5",
      "categoryId": 5,
      "category": "Category 5"
    }
  ]
}
```

## API Documentation

Swagger documentation is enabled for this project.  After running the project, you can access the Swagger UI by navigating to `https://localhost:{port}/swagger`, replacing `{port}` with the port number your application is running on.  This provides interactive documentation for all available endpoints.

## Contributing Guidelines

Contributions are welcome! Please follow these guidelines:

1.  Fork the repository.
2.  Create a new branch for your feature or bug fix.
3.  Make your changes and commit them with clear, concise messages.
4.  Submit a pull request.

