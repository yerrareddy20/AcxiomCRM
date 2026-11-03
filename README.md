# AcxiomCRM – Customer Relationship Management System

## Overview
AcxiomCRM is a web-based Customer Relationship Management (CRM) application developed using ASP.NET Core MVC and C#. It helps organizations manage customers, leads, opportunities, follow-ups, and user accounts in one centralized system.

The application provides a dashboard to monitor CRM activities and supports role-based access and audit logging.

## Features

- **Authentication:** User registration and login using ASP.NET Core Identity.
- **Customer Management:** Add, view, edit, delete, and search customer records.
- **Lead Management:** Manage leads, their sources, statuses, and expected values.
- **Opportunity Management:** Track sales opportunities, amounts, probabilities, and expected closing dates.
- **Follow-Up Management:** Schedule and manage customer follow-ups.
- **Dashboard:** View customer, lead, opportunity, and pending follow-up statistics with charts.
- **User Management:** Create and manage users with Admin, Manager, and Sales Executive roles.
- **Audit Logs:** Maintain records of important application activities.
- **Validation:** Apply input validation to prevent invalid data.

## Technologies Used

| Technology | Purpose |
|---|---|
| C# | Backend programming |
| ASP.NET Core MVC | Web application framework |
| Entity Framework Core | Database operations |
| SQLite | Database |
| ASP.NET Core Identity | Authentication and authorization |
| HTML & CSS | Frontend structure and styling |
| JavaScript | Client-side functionality |
| Bootstrap | Responsive user interface |
| Chart.js | Dashboard charts |

## Project Structure

```text
AcxiomCRM/
├── Controllers/
├── Data/
├── Models/
├── Views/
├── wwwroot/
├── Properties/
├── Program.cs
├── appsettings.json
└── AcxiomCRM.csproj
```

## Installation and Setup

### Prerequisites
- .NET 8 SDK
- Visual Studio Code or Visual Studio
- Git

### Steps to Run

1. Clone the repository:

```bash
git clone https://github.com/yerrareddy20/AcxiomCRM.git
```

2. Navigate
