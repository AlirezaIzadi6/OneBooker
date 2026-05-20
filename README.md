# OneBooker 🎫

OneBooker is a **Universal Event Booking System** designed for seamless reservations across concerts, cinemas, theaters, and live events. Built with **.NET 9**, this project is a high-fidelity implementation of **Clean Architecture** and **Modular Monolith** principles.

## 🎯 Project Philosophy & Evolution

The core mission of OneBooker is to demonstrate that a well-structured monolith is the best foundation for a scalable, distributed system.

- **Architectural Integrity**: Strictly following Robert C. Martin's (Uncle Bob) Clean Architecture to maintain high decoupling and clear boundaries between business rules and infrastructure.
- **Dependency Rule**: Rigorous enforcement of the Dependency Rule—dependencies point only towards the core (Domain -> Application -> Infrastructure/API).
- **Monolith to Microservices Path**: By starting as a **Modular Monolith**, we establish firm bounded contexts. This approach allows us to defer the complexity of distributed systems until needed, ensuring a seamless future transition to **Microservices**.

## 🚀 Features (Current & Roadmap)

### User Management
- [x] Identity & Authentication (JWT-based)
- [ ] Role-based Access Control
- [ ] Profile Management

### Address Management
- [x] Global Country Management
- [ ] City and Venue Location Management

### 🏗️ Coming Soon: The Event Booking Engine
- **Event & Venue Management**: A generic engine to manage diverse event types (Concerts, Cinema sessions, Festivals) and their venue layouts.
- **Advanced Reservation Logic**: Sophisticated booking flows including seat selection, pricing tiers, and real-time availability.
- **Payments**: Centralized payment gateway integration.
- **Domain Events**: Internal event-driven communication (e.g., TicketIssued, ReservationExpired).

## 🛠️ Tech Stack

- **Framework**: .NET 9
- **Database**: SQL Server
- **ORM**: Entity Framework Core
- **Authentication**: JWT Bearer
- **DI Container**: Scrutor (for automatic service registration)
- **Documentation**: Swagger/OpenAPI

## 🏗️ Architecture Overview

The project is structured to protect the "Business Rules" from "Infrastructure":

- **Api/**: Presentation Layer. Decoupled from business logic via interfaces.
- **Modules/**: Bounded Contexts (Users, Events, Reservations).
  - `Domain/`: Enterprise-wide Business Rules (Entities, Value Objects).
  - `Application/`: Application-specific Business Rules (Use Cases).
  - `Infrastructure/`: Details like Persistence, Identity providers, and external APIs.
- **Shared/**: Common abstractions and cross-cutting concerns that don't violate module boundaries.

## 🚦 Getting Started

### Prerequisites
- .NET 9 SDK
- SQL Server

### Configuration
1. Clone the repository.
2. Update the Connection String in `OneBooker/appsettings.json`.
3. Database migrations run automatically on startup.

### Running the Project
```bash
dotnet run --project OneBooker
```
Explore the API via Swagger at `/swagger`.

## 📈 Roadmap
- [x] Modular Monolith Foundation
- [x] User Identity System
- [ ] Venue & Event Management (Bookable Items)
- [ ] Core Reservation Engine (Seat Mapping & Booking)
- [ ] Payment Integration
- [ ] Transition to Microservices (Phase 2)
