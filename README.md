# Dotnet Template

This is an project showcaising the Clean Architecture principles in .NET Core. It organizes the codebase into distinct layers for scalability, maintainability, and separation of concerns.

## Project Architecture

### 1. Domain

The heart of the application, [Domain](./src/Domain), holds the domain entities and business logic. It represents the core of your application and remains independent of any external frameworks.

### 2. Application

[Application](./src/Application) encapsulates application-specific business rules, use cases, and application services. It acts as a mediator between the domain layer and the infrastructure layer.

### 3. Infrastructure

[Infrastructure](./src/Infrastructure) contains implementation details that are external to the application. It includes data access, external services, and other infrastructure concerns.

### 4. Identity

[Identity](./src/Identity) focuses on user identity and authentication aspects, handling user-related functionalities.

### 5. Persistence

The [Persistence](./src/Persistence) project deals with data storage and retrieval, using technologies such as Entity Framework Core to interact with the database.

### 6. Api

[Api](./src/Api) serves as the entry point for the Web API application. It utilizes the Clean Architecture principles to handle incoming HTTP requests and coordinate actions across different layers.

### 7. MVC

[MVC](./src/Mvc) represents the MVC (Model-View-Controller) layer, handling the presentation logic for the user interface. It interacts with the application layer to retrieve and display data.

## References

- [Clean Architecture: A Craftsman's Guide to Software Structure and Design](https://www.amazon.com/Clean-Architecture-Craftsmans-Software-Structure/dp/0134494164)
- [Domain-Driven Design: Tackling Complexity in the Heart of Software](https://www.amazon.com/Domain-Driven-Design-Tackling-Complexity-Software/dp/0321125215)
- [Exploring Clean Architecture in ASP.NET Core](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures#clean-architecture)
- [The Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
- [Clean Coders](https://cleancoders.com/)
- [Stack Overflow - Clean Architecture](https://stackoverflow.com/questions/tagged/clean-architecture)

## Stack

- .NET Core 8
- FluentValidation
- MediatR
- AutoMapper
- CQRS (Command Query Responsibility Segregation)
- Entity Framework Core
- Serilog
- JWT (JSON Web Tokens)
- Authorization
- Globalization
- Dependency Injection
- Docker
- GitHub Actions

## Deployment

To deploy the application, follow the deployment instructions in the [Deployment](#deployment) section.

## Continuous Integration / Continuous Deployment (CI/CD)

This project is configured for CI/CD with [GitHub Actions](https://github.com/features/actions). The workflow is triggered on each push to the main branch, running build and test tasks.

### Docker

Run the application in Docker containers using Docker Compose:

1. **Build and run the Docker containers:**

   ```bash
   docker-compose up -d
   ```

2. **Access the Web API:**

   - The API will be accessible at [http://localhost:5000](http://localhost:5000).

3. **Access the MVC application:**

   - The MVC application will be accessible at [http://localhost:5001](http://localhost:5001).

4. **Stop the containers:**

   ```bash
   docker-compose down
   ```

### CI/CD Pipeline

The CI/CD pipeline is automatically triggered on each push to the main branch. It includes the following steps:

1. **Build:**

   - Builds the application, ensuring the code compiles successfully.

2. **Test:**

   - Runs automated tests to verify the integrity of the codebase.

3. **Publish:**

   - Publishes the application, preparing it for deployment.

4. **Deploy:**
   - Deploys the application to the specified environment.

## Usage

This Web API provides a basic structure adhering to Clean Architecture. Customize it based on your specific application needs.
