# Talabat API

## Description

This repository contains the backend API for an Talabat application, similar to Talabat. It provides endpoints for retrieving products, brands, and categories, with support for pagination, filtering, and sorting.

## Features and Functionality

*   **Product Retrieval:**
    *   Retrieve a paginated list of products with filtering by brand, category, and search term.
    *   Retrieve a specific product by its ID.
    *   Sorting options for products based on name and price (ascending/descending).
*   **Brand and Category Retrieval:**
    *   Retrieve a list of all product brands.
    *   Retrieve a list of all product categories.
*   **API Endpoints:**
    *   `/api/Products`: Retrieves products with optional filtering, sorting, and pagination.
    *   `/api/Products/{id}`: Retrieves a specific product by ID.
    *   `/api/Products/brands`: Retrieves all brands.
    *   `/api/Products/categories`: Retrieves all categories.
*   **Data Seeding:** The application includes data seeding for initial product, brand, and category data.
*   **Database Migrations:**  Database migrations are included for easy setup and schema management.

## Technology Stack

*   **ASP.NET Core:**  The API is built using ASP.NET Core.
*   **Entity Framework Core (EF Core):**  EF Core is used as the ORM to interact with the database.
*   **SQL Server:** The application is configured to use SQL Server as the database.
*   **AutoMapper:** Used for mapping between domain entities and DTOs.
*   **.NET 9.0**: Target Framework.
*   **C# 13.0**: Programming Language.

## Prerequisites

Before running the application, ensure that you have the following installed:

*   **.NET SDK 9.0 or later:** Download from [https://dotnet.microsoft.com/en-us/download](https://dotnet.microsoft.com/en-us/download)
*   **SQL Server:**  A SQL Server instance is required.  SQL Server Express is a free option.
*   **An IDE (e.g., Visual Studio, Visual Studio Code):**  Recommended for development and debugging.

## Installation Instructions

1.  **Clone the repository:**

    ```bash
    git clone https://github.com/muhammadabdelgawad/Talabat-E-Commerce.git
    cd Talabat-E-Commerce
    ```

2.  **Update the database connection string:**

    *   Open the `Talabat.APIs/appsettings.json` file.
    *   Locate the `StoreConnection` connection string.
    *   Modify the connection string to point to your SQL Server instance.  For example:

        ```json
        {
          "ConnectionStrings": {
            "StoreConnection": "Data Source=YOUR_SERVER;Initial Catalog=TalabatStoreDB;Integrated Security=True;TrustServerCertificate=True"
          },
          "Urls": {
            "ApiBaseUrl": "https://localhost:7211"
          }
        }
        ```

        Replace `YOUR_SERVER` with the name of your SQL Server instance.

3.  **Apply database migrations:**

    *   Navigate to the `Talabat.APIs` directory.
    *   Run the following command in the Package Manager Console:

        ```bash
        dotnet ef database update --project ../Talabat.Infrastructure.Persistence
        ```

4.  **Build the project:**

    *   Navigate to the `Talabat.APIs` directory.
    *   Run the following command:

        ```bash
        dotnet build
        ```

## Usage Guide

1.  **Run the application:**

    *   Navigate to the `Talabat.APIs` directory.
    *   Run the following command:

        ```bash
        dotnet run
        ```

2.  **Access the API:**

    *   The API will be available at `https://localhost:7211` (or the URL configured in `appsettings.json`).
    *   You can use a tool like Swagger UI (enabled in development mode), Postman, or curl to send requests to the API endpoints.

## API Documentation

The API documentation is available through Swagger UI when running the application in Development mode.  Navigate to `https://localhost:7211/swagger` in your browser.

### Product Endpoints

*   **GET /api/Products**

    *   **Description:** Retrieves a paginated list of products.
    *   **Query Parameters:**
        *   `sort` (string, optional): Sorting criteria ("name", "priceAsc", "priceDesc").  Default is "name".
        *   `brandId` (integer, optional): Filter by brand ID.
        *   `categoryId` (integer, optional): Filter by category ID.
        *   `pageIndex` (integer, optional): Page number (default: 1).
        *   `pageSize` (integer, optional): Number of products per page (default: 10, max: 100).
        *   `search` (string, optional): Search term (case-insensitive).
    *   **Response:** `Pagination<ProductToReturnDto>`

*   **GET /api/Products/{id}**

    *   **Description:** Retrieves a product by its ID.
    *   **Path Parameter:**
        *   `id` (integer, required): Product ID.
    *   **Response:** `ProductToReturnDto`

*   **GET /api/Products/brands**

    *   **Description:** Retrieves a list of all brands.
    *   **Response:** `IEnumerable<BrandDto>`

*   **GET /api/Products/categories**

    *   **Description:** Retrieves a list of all categories.
    *   **Response:** `IEnumerable<CategoryDto>`

### Data Transfer Objects (DTOs)

*   **ProductToReturnDto:**

    ```json
    {
      "id": 1,
      "name": "Product Name",
      "description": "Product Description",
      "pictureUrl": "https://localhost:7211/images/product.jpg",
      "price": 19.99,
      "brandId": 1,
      "brand": "Brand Name",
      "categoryId": 1,
      "category": "Category Name"
    }
    ```

*   **BrandDto:**

    ```json
    {
      "id": 1,
      "name": "Brand Name"
    }
    ```

*   **CategoryDto:**

    ```json
    {
      "id": 1,
      "name": "Category Name"
    }
    ```

*   **Pagination<T>:**

    ```json
    {
      "pageIndex": 1,
      "pageSize": 10,
      "count": 100,
      "data": [
        // Array of T (e.g., ProductToReturnDto)
      ]
    }
    ```

### Example Usage (curl)

*   **Get all products (paginated):**

    ```bash
    curl https://localhost:7211/api/Products
    ```

*   **Get products filtered by brand ID 1:**

    ```bash
    curl "https://localhost:7211/api/Products?brandId=1"
    ```

*   **Get products sorted by price in descending order:**

    ```bash
    curl "https://localhost:7211/api/Products?sort=priceDesc"
    ```

*   **Get product with ID 5:**

    ```bash
    curl https://localhost:7211/api/Products/5
    ```

## Contributing Guidelines

Contributions are welcome!  To contribute to this project, please follow these steps:

1.  Fork the repository.
2.  Create a new branch for your feature or bug fix.
3.  Make your changes.
4.  Ensure that your code follows the existing coding style.
5.  Write unit tests for your changes.
6.  Commit your changes with a clear and descriptive commit message.
7.  Push your branch to your forked repository.
8.  Create a pull request to the `master` branch of the original repository.

