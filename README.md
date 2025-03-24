# Healthcare Organization API (Minimal API)

## Overview
This is a minimal Web API project that provides healthcare organization data in JSON format. The data is extracted from a SQL Server database and is designed to be consumed by front-end applications. The project follows clean architecture principles and applies key design patterns for maintainability and scalability.

## Features
- **Minimal API Implementation**: Efficient and easy-to-maintain endpoints.
- **Healthcare Data Management**: Provides structured healthcare organization information.
- **Database Integration**: Extracts data from a SQL Server database.
- **Authentication & Authorization**: Secure access using JWT-based authentication.
- **Logging & Monitoring**: Integrated logging and exception handling.

## Technologies Used
- **Backend**: ASP.NET Core Minimal API (.NET 8)
- **Database**: SQL Server with Entity Framework Core
- **Architecture**: Clean Architecture (Onion Architecture principles)
- **Design Patterns**: Repository Pattern, Unit of Work, Specification Pattern
- **Authentication**: Identity with JWT tokens

## Installation
1. Clone the repository.
2. Restore dependencies:
   ```sh
   dotnet restore
   ```
3. Configure the database connection in `appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=your-server;Database=your-db;User Id=your-user;Password=your-password;"
     }
   }
   ```
4. Apply migrations and update the database:
   ```sh
   dotnet ef database update
   ```
5. Run the application:
   ```sh
   dotnet run
   ```



## License
This project is licensed under the MIT License.

## Contact
For support or inquiries, reach out via or email at ismail.mohammed.atef@gmail.com.

