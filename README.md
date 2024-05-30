CMS App
CMS App is a full-stack web application for managing customers. It provides functionalities for creating, updating, deleting, and viewing customer data.

Technologies Used

Frontend:
- Vue.js
- Axios

Backend:
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server

Dependencies:
- ASP.NET Core 3.1.426
- Entity Framework Core 3.1.13
- Swagger (Swashbuckle.AspNetCore) 6.2.3
- JWT Authentication (Microsoft.AspNetCore.Authentication.JwtBearer) 3.1.18
- SQL Server Database Provider (Microsoft.EntityFrameworkCore.SqlServer) 3.1.13
- Entity Framework Core Design (Microsoft.EntityFrameworkCore.Design) 3.1.13
- System.Data.SqlClient 4.8.6
- System.IdentityModel.Tokens.Jwt 7.6.0

Setup Instructions:

Clone the Repository:
git clone https://github.com/mark-war/cms-app.git

Backend Setup:
Navigate to the backend directory:
cd backend

Install dependencies:
dotnet restore

Create and seed the database:
- execute cms_app_db_20220528_create.sql in SSMS
- fix the connection string (DefaultConnection) in appsettings.json (SERVER and user credentials if required)
dotnet tool install --global dotnet-ef --version 3.1.13 (this is to support the version of the dotnet core used in the project)
dotnet ef database update

Run the backend server:
dotnet run

Frontend Setup:

Navigate to the frontend directory:
cd frontend

Install dependencies:
npm install

Run the frontend server:
npm run serve

Accessing the Application:
The backend server runs on https://localhost:5001.
The frontend server runs on http://localhost:8080.
Access the application by visiting http://localhost:8080 in your web browser.
Swagger: https://localhost:5001/swagger/index.html

API Endpoints
GET /api/customers: Get all customers.
GET /api/customers/{id}: Get a specific customer by ID.
POST /api/customers: Create a new customer.
PUT /api/customers/{id}: Update an existing customer.
DELETE /api/customers/{id}: Delete a customer.

Contributors
[Mark War](https://github.com/mark-war)