# Part 2: API Testing

##  Overview
This part focuses on basic API testing using C#.  
The tests are written using the xUnit framework and HttpClient to validate REST API behavior.

---

##  Tools Used
- Language: C#
- Test Framework: xUnit
- HTTP Client: HttpClient
- API: JSONPlaceholder (https://jsonplaceholder.typicode.com/)

---

##  Approach
- Used HttpClient to send API requests (GET and POST)
- Validated responses using status codes
- Checked basic response structure and data
- Covered both positive and negative scenarios

---

##  Test Cases Implemented

### 1. GET Request - Fetch User
- Endpoint: `/users/1`
- Validations:
  - Status code is 200
  - Response contains fields like `id`, `name`, and `email`

---

### 2. POST Request - Create Post
- Endpoint: `/posts`
- Sent sample JSON data
- Validations:
  - Status code is 201
  - Response contains created data and generated `id`

---

### 3. Error Handling - Invalid User
- Endpoint: `/users/999`
- Validations:
  - Status code is 404
  - Response is empty or valid error response

---

## How to Run

1. Open the project in Visual Studio
2. Build the solution
3. Run tests using Test Explorer

---

##  Summary
This implementation demonstrates basic API testing skills such as:
- Sending HTTP requests
- Validating responses
- Handling success and error scenarios