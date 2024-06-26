Customer Management System App
    CMS App is a full-stack web application for managing customers. It provides functionalities for creating, updating, deleting, and viewing customer data.

Technologies Used:

Frontend:
    Vue.js
    Axios

Backend:
    ASP.NET Core Web API
    Entity Framework Core
    SQL Server

Dependencies:
    ASP.NET Core 3.1.426
    Entity Framework Core 3.1.13
    Swagger (Swashbuckle.AspNetCore) 6.2.3
    JWT Authentication (Microsoft.AspNetCore.Authentication.JwtBearer) 3.1.18
    SQL Server Database Provider (Microsoft.EntityFrameworkCore.SqlServer) 3.1.13
    Entity Framework Core Design (Microsoft.EntityFrameworkCore.Design) 3.1.13
    System.Data.SqlClient 4.8.6
    System.IdentityModel.Tokens.Jwt 7.6.0

Setup Instructions:

Clone the Repository:
    git clone https://github.com/mark-war/cms-app.git

Backend Setup:
Navigate to the backend directory:
    cd backend

Install dependencies:
    dotnet restore

Create and seed the database:
    execute cms_app_db_20220528_create.sql in SSMS (SQL Server Management Studio)
    fix the connection string (DefaultConnection) in appsettings.json (SERVER and user credentials if required)

    dotnet tool install --global dotnet-ef --version 3.1.13 (this is to support the version of the dotnet core used in the project)
    dotnet ef database update

Run the backend server:
    dotnet run

Frontend Setup:
Navigate to the frontend directory:
    cd frontend

Install dependencies:
    npm install
    (create an environment variable for the API URL if port 5001 is already used)
        VUE_APP_API_BASE_URL=https://localhost:5001

Run the frontend server:
    npm run serve

Accessing the Application:
    The backend server runs on https://localhost:5001.
    The frontend server runs on http://localhost:8080.
    Access the application by visiting http://localhost:8080 in your web browser.
    Swagger: https://localhost:5001/swagger/index.html

Testing in Swagger:
    Scroll down to Token (Execute the generate method and capture the token.)
    Scroll up above, click Authorize button, and provide this input.
    Bearer [token generated]
    Then click Authorize and Close.
    You can now test any Customer methods available.

API Endpoints
Customers

GET /Customer/GetAll
    Description: Get all customers.
    Authentication: Required
    Response: Returns a list of all customers.

GET /Customer/GetById/{id}
    Description: Get a specific customer by ID.
    Authentication: Required
    Parameters:
    id: Customer ID
    Response: Returns the customer object if found, otherwise returns false.

POST /Customer/Create
    Description: Create a new customer.
    Authentication: Required
    Request Body: Customer object (JSON)
    Response: Returns true if the customer was successfully created, otherwise returns an error message.

PUT /Customer/Update/{id}
    Description: Update an existing customer.
    Authentication: Required
    Parameters:
    id: Customer ID
    Request Body: Customer object (JSON)
    Response: Returns true if the customer was successfully updated, otherwise returns an error message.

DELETE /Customer/Remove/{id}
    Description: Delete a customer.
    Authentication: Required
    Parameters:
    id: Customer ID
    Response: Returns true if the customer was successfully deleted, otherwise returns an error message.

Contributors
[Mark War](https://github.com/mark-war)