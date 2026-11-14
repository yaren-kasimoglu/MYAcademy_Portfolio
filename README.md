# Dynamic Portfolio & Admin Dashboard

**English** | [Türkçe](README.tr.md)

A responsive, database-driven personal portfolio built with **ASP.NET Core MVC**, **C#**, **Entity Framework Core**, **Microsoft SQL Server**, and **Bootstrap 5**. The application combines a public portfolio with an administration panel for managing content, projects, and contact messages.

## Features

### Public portfolio
- Dynamic hero, about, education, experience, skills, projects, and contact sections using Razor ViewComponents
- Category-based project filtering and responsive layouts
- Animated text, scroll effects, and interactive navigation
- Contact form with validation and database-backed message submission
- CV download

### Admin panel
- Dashboard with project, skill, education, experience, and message statistics
- Recent projects and messages
- CRUD operations for portfolio content
- Project and skill category management
- Active/inactive project status
- Message details and read/unread tracking
- CV management

## Technologies

| Area | Stack |
| --- | --- |
| Backend | C#, ASP.NET Core MVC |
| Data access | Entity Framework Core, LINQ |
| Database | Microsoft SQL Server |
| Frontend | Razor, HTML5, CSS3, JavaScript |
| UI | Bootstrap 5, Bootstrap Icons |
| Architecture | MVC, Razor ViewComponents |
| Tools | Visual Studio, Git, GitHub |

## Project Structure

```text
MYAcademy_Portfolio/
├── Areas/Admin/
├── Controllers/
├── Context/
├── Entities/
├── Models/
├── ViewComponents/
├── Views/
├── wwwroot/
├── Migrations/
└── Program.cs
```

## Getting Started

1. Clone the repository and open the solution in Visual Studio.
2. Configure a local SQL Server connection string using user secrets or environment variables.
3. Restore dependencies and apply the project's existing EF Core migrations:

```bash
dotnet restore
dotnet ef database update
```

4. Run the application:

```bash
dotnet run
```

> Requires SQL Server, the .NET SDK version targeted by the project, and the EF Core CLI for `dotnet ef`. Never commit credentials or secrets.

## Screenshots

Screenshots of the portfolio and dashboard will be added soon.

## Learning Outcomes

This project strengthened my experience with MVC architecture, EF Core and LINQ, CRUD operations, relational data models, reusable ViewComponents, dashboard reporting, and responsive web interfaces.

## Developer

**Yaren Kasımoğlu**  
Computer Engineer · .NET Developer · Digitalization & Automation

Developed as part of my ASP.NET Core MVC learning and portfolio development journey.
