# RestAPIPro

**RestAPIPro** is a RESTful API designed for managing products in an inventory system. This API supports basic CRUD (Create, Read, Update, Delete) operations and includes versioning (v1 and v2) to allow backward compatibility while adding new features.

## Features

- **CRUD Operations**: Perform Create, Read, Update, and Delete operations on products.
- **Versioning**: Supports two versions of the API (v1 and v2) for backward compatibility.
- **Swagger UI**: Interactive documentation for testing the API endpoints.
- **In-memory Storage**: The data is stored in memory for simplicity (not persistent).

## API Endpoints

### Version 1 (v1) API Endpoints

Version 1 provides basic CRUD functionality for managing products:

- **GET /api/v1/products**: Retrieve a list of all products.
- **GET /api/v1/products/{id}**: Retrieve a product by its unique ID.
- **POST /api/v1/products**: Create a new product.
- **PUT /api/v1/products/{id}**: Update an existing product by its ID.
- **DELETE /api/v1/products/{id}**: Delete a product by its ID.

### Version 2 (v2) API Endpoints

Version 2 adds new features, such as additional product categories. It provides the same CRUD operations as Version 1 but with enhancements.

- **GET /api/v2/products**: Retrieve a list of all products.
- **GET /api/v2/products/{id}**: Retrieve a product by its unique ID.
- **POST /api/v2/products**: Create a new product.
- **PUT /api/v2/products/{id}**: Update an existing product by its ID.
- **DELETE /api/v2/products/{id}**: Delete a product by its ID.

### Response Format

All responses from the API are in **JSON** format. Successful requests will return a 200 OK or 201 Created response, while errors will return appropriate status codes (e.g., 404 for Not Found, 400 for Bad Request).

## Getting Started

To get the project up and running locally, follow these steps:

### Prerequisites

- .NET 6.0 or later
- Visual Studio or Visual Studio Code
- A modern web browser (for Swagger UI)

### Installation

1. **Clone the repository**:

   ```bash
   git clone https://github.com/yourusername/RestAPIPro.git
   ```
