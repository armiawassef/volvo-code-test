# Congestion Tax Calculator C# Project

Welcome to the Congestion Tax Calculator project! This application is designed to calculate congestion taxes using a web API built with C#, following the principles of Domain-Driven Design (DDD) and utilizing Inversion of Control (IoC) for managing dependencies. The project also utilizes Entity Framework Code First for data storage.

## Table of Contents

- [Introduction](#introduction)
- [Features](#features)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Project Structure](#project-structure)
- [Configuration](#configuration)
- [Usage](#usage)
- [API Endpoints](#api-endpoints)
- [Dependencies](#dependencies)
- [Contributing](#contributing)
- [License](#license)

## Introduction

The Congestion Tax Calculator project is developed to provide a solution for calculating congestion taxes based on certain criteria and rules. It utilizes a web API to expose the tax calculation functionality, follows Domain-Driven Design (DDD) principles to maintain a clear separation of concerns, and uses Inversion of Control (IoC) for efficient dependency management. The project's data storage is handled using Entity Framework Code First, allowing seamless interaction with a SQLLite database.

## Features

- Calculate congestion taxes based on provided criteria.
- Flexible configuration of tax rules and rates.
- Web API for easy integration into other applications.
- Utilization of Domain-Driven Design principles for maintainability.
- Inversion of Control for efficient dependency management.
- Entity Framework Code First for seamless data storage.

## Getting Started

### Prerequisites

Before you begin, make sure you have the following prerequisites:

- Microsoft Visual Studio 2019 or 2022 compatible with .NET 7

### Installation

1. Clone the repository to your local machine:

   ```sh
   git clone https://github.com/armiawassef/volvo-code-test.git
   ```
   
2. Navigate to the project directory
3. Build the project
   
## Project Structure

The project follows a structured organization:

- **CongestionTaxCalculator.Api**: Web API application.
- **CongestionTaxCalculator.Application**: Application services and use cases.
- **CongestionTaxCalculator.Domain**: Domain entities, aggregates, and business logic.
- **CongestionTaxCalculator.Common**: Generic repositories, and business repositories.
- **CongestionTaxCalculator.Infrastructure**: Infrastructure concerns, including data access and IoC setup.
- **CongestionTaxCalculator.Tests**: Unit tests.

## Usage

1. Start the application by running the web API.

2. Use API endpoints to calculate congestion taxes based on specific criteria.

## API Endpoints

- `GET /api/CongestionTaxCalculator/calculate-tax`: Calculate congestion tax based on provided criteria.

## Dependencies

The project relies on several key technologies and libraries, including:

- .NET 7
- Entity Framework
- Inversion of Control (IoC) container (e.g., Autofac, Unity)
- JSON.NET (Newtonsoft.Json) for JSON handling
- SQLite database provider
- Entity Framework Data Seeding
- Repository Design Pattern

Please refer to the project's `*.csproj` files for a complete list of dependencies.
