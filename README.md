# FlyHigh

Filters flights based on

- From Airport
- To Airport
- Airline code
- Any combination of the above three

QueryParams for API endpoint
- FromAirport
- ToAirport
- Airline
eg;
``/api/Flights/flights?FromAirport=BER&ToAirport=CGN&Airline=EW``

## Prequisites
Install the following packages from NugetPackage Manager
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer
- LinqKit
- AutoMapper.Extensions.Microsoft.DependencyInjection
- Newtonsoft.Json
Or execute command
```
dotnet restore
```

## Add Configuration
For security purpose it is not advised to read connectionstring from appSettings. For local testing it is suggested but in case of dev/qa/prod connectionstring value should be read from KeyVault.

Set local connectionstring to appSettings
``ConnectionStrings:FlightsDbConnString ``

## Build & Run
```
dotnet build
dotnet run
```

## Application Specifications and framework choices
- Framework - .NET 8, ASP.NET Core Web API
- Framework stucture follows Controller-Service-Repository pattern to ensure separation of concerns and provides layers of abstraction
- EF core (ORM) is used for reading data from SqlServer. It is lightweight and .net objects can be used to perform data operations.
- Models based on database table is used for data binding
- DTOs are used to avoid exposing column names
- PredicateBuilder is used to perform flexible search functionality
- AutoMapper is used for mapping Models to DTOs
- Implemented try/catch to handle exceptions
- Created local logger service to log information into a local file
- Alternatively Serilogs can be used to do the same with more dimensions (Nuget packages available)

## If provided more time
- Would implement Unit testing to improve code coverage
- Read secret key values from KeyVault
- Implement caching to reduce load and improve performance
- Implemented UI forms for good user experience
- Implement token based(jwttoken) authentication provided users

















