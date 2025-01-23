# Library Management System API

## Overview
This API allows managing a simple in-memory library system, providing endpoints to perform CRUD operations on books.

---

## API Endpoints

### **1. Add a New Book**
- **Endpoint**: `POST /api/books`
- **Description**: Adds a new book to the library.
- **Request Body**:
  ```json
  {
      "title": "The Great Gatsby",
      "author": "F. Scott Fitzgerald",
      "isbn": "1234567890",
      "isAvailable": true
  }
  ```
- **Response**:
  - 201 Created: Book added successfully.
  - 409 Conflict: Duplicate ISBN.

### **2. Retrieve All Books**
- **Endpoint**: `GET /api/books`
- **Description**: Fetches all books in the library.
- **Response**:
  - 200 OK:
    ```json
    [
        {
            "title": "The Great Gatsby",
            "author": "F. Scott Fitzgerald",
            "isbn": "1234567890",
            "isAvailable": true
        }
    ]
    ```

### **3. Retrieve Books by Title**
- **Endpoint**: `GET /api/books/{title}`
- **Description**: Retrieves books matching the given title.
- **Response**:
  - 200 OK: List of books.
  - 404 Not Found: No books found with the title.

### **4. Retrieve Book by ISBN**
- **Endpoint**: `GET /api/books/isbn/{isbn}`
- **Description**: Fetches details of a book by ISBN.
- **Response**:
  - 200 OK: Book details.
  - 404 Not Found: No book found with the ISBN.

### **5. Update a Book**
- **Endpoint**: `PUT /api/books/{isbn}`
- **Description**: Updates an existing book by ISBN.
- **Request Body**:
  ```json
  {
      "title": "Updated Title",
      "author": "Updated Author",
      "isbn": "1234567890",
      "isAvailable": false
  }
  ```
- **Response**:
  - 204 No Content: Book updated.
  - 404 Not Found: Book not found.

### **6. Delete a Book**
- **Endpoint**: `DELETE /api/books/{isbn}`
- **Description**: Deletes a book by ISBN.
- **Response**:
  - 204 No Content: Book deleted.
  - 404 Not Found: Book not found.

## HTTP Request Samples

### 1. Add a Book
```http
POST https://localhost:7267/api/books
Content-Type: application/json

{
    "title": "The Great Gatsby",
    "author": "F. Scott Fitzgerald",
    "isbn": "1234567890",
    "isAvailable": true
}
```

### 2. Retrieve All Books
```http
GET https://localhost:7267/api/books
Accept: application/json
```

### 3. Retrieve Books by Title
```http
GET https://localhost:7267/api/books/Gatsby
Accept: application/json
```

### 4. Retrieve Book by ISBN
```http
GET https://localhost:7267/api/books/isbn/1234567890
Accept: application/json
```

### 5. Update a Book
```http
PUT https://localhost:7267/api/books/1234567890
Content-Type: application/json

{
    "title": "Updated Title",
    "author": "Updated Author",
    "isbn": "1234567890",
    "isAvailable": false
}
```

### 6. Delete a Book
```http
DELETE https://localhost:7267/api/books/1234567890
```

## Running the API
- Open the project in Visual Studio.
- Build and run the application (use F5 or Ctrl+F5).
- Access the API at:
  - HTTPS: https://localhost:7267
  - HTTP: http://localhost:5139

## Notes
- The API uses in-memory storage; data will reset upon application restart.
