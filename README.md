# Products Management API
### Overview
The Products Management API is a project designed to manage product and category data following Clean Architecture principles. It utilizes CQRS, MediatR for request/response handling, Domain Events for maintaining consistency, and DDD (Domain-Driven Design). The API provides CRUD operations for both Products and Categories, while ensuring synchronization of product counts within categories using domain events.

### Architecture
The project is structured according to Clean Architecture, with separation of concerns across four layers:

* API Layer: Contains controllers and handles HTTP requests.

* Application Layer: Contains the business logic, CQRS handlers, commands, and queries.

* Domain Layer: Contains the core domain models, events, and event handlers.

* Infrastructure Layer: Manages data persistence, repositories, and any external dependencies.

### Technologies Used
ASP.NET Core 8
EF Core with an in-memory database (for development and testing)
MediatR for implementing CQRS
