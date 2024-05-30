CMS App
CMS App is a full-stack web application for managing customers. It provides functionalities for creating, updating, deleting, and viewing customer data.

Technologies Used

Frontend:
Vue.js
Axios
Bootstrap

Backend:
ASP.NET Core Web API
Entity Framework Core
SQL Server
Setup Instructions

Clone the Repository:
git clone https://github.com/mark-war/cms-app.git

Backend Setup:
Navigate to the backend directory:
cd backend

Install dependencies:
dotnet restore

Create and seed the database:
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

API Endpoints
GET /api/customers: Get all customers.
GET /api/customers/{id}: Get a specific customer by ID.
POST /api/customers: Create a new customer.
PUT /api/customers/{id}: Update an existing customer.
DELETE /api/customers/{id}: Delete a customer.

Contributors
[Mark War](https://github.com/mark-war)

License
This project is licensed under the MIT License.