# Restaurant Website

This project is built with React and .NET Core following the Clean Architecture principles.

## Project Structure

- **API**: Contains the Web API that handles controllers and SignalR for notifications.
- **Domain**: Contains the entities used for SQL Server (Restaurant, Menu, Order, AppUser).
- **Application**: Contains all the business logic with MediatR and AutoMapper.
- **Identities**: Contains the IdentityDbContext and repository that handles all logic with the users database.
- **Infrastructure**: Contains the database context for the Restaurants.

## Technologies Used

- **Frontend**: React
- **Backend**: .NET Core
- **Database**: SQL Server
- **Libraries**: MediatR, AutoMapper, SignalR

## Getting Started

1. Clone the repository.
2. Navigate to the project directory.
3. Set up the SQL Server database.
4. Configure the connection strings in the `appsettings.json` file.
5. Run the migrations to set up the database schema.
6. Start the API project.
7. Navigate to the frontend directory and run the React application.
