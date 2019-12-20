# TS.BlogSystem
Simple Blog solution 

## Technologies
* .NET Core 3.1
* ASP .NET Core 3.1
* Entity Framework Core 3.1

### Prerequisites
- Visual Studio 2019 preview
- .NET Core SDK  3.0 

## Getting Started
1. Clone or download repository
2. Open solution in VS 2019
3. Open Package-Manager console, choose TS.BlogSystem.Data proj and run `Update-Database`
4. Hit F5 to launch the project

## Overview
### Architecture:
- Clean Architecture
- Repository and Generic Repository

### TS.BlogSystem.Core

This layer contains all entities, enums, exceptions, interfaces, types and logic specific to the domain layer.


### TS.BlogSystem.Data

This layer contains all data retrive logic. It is dependent on the Core layer, but has no dependencies on any other layer or project. This layer contains data context and repository implementations.


### TS.BlogSystem.Services

This layer contains service classes for magnaging entities, web services, smtp, and so on. These classes should be based on interfaces defined within the Core layer. It is dependent on the Core layer and Data layer.

### TS.BlogSystem.Web

This is Presentation layer based on ASP.NET Core 3, depends on both the Services and Core layers. Main layout and Admin Panel styled with bootstrap 4.

## License
This project is licensed with the [MIT license](LICENSE).
