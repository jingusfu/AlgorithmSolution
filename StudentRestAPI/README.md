# Student REST API

This project is a simple ASP.NET Core Web API written in C# for managing student records using an in-memory repository. 

## Features

- CRUD operations for Student entities
- In-memory repository with no external database dependency
- Custom validation for student fields
	DOB must be before today
	Valid email address (build-in)
	Valid US phone format
	Valid grade ("K" or a number between 1 and 12, doesn't say case sensitve specifically, assume both "K" and "k" are fine)
	Required field constraint 
	Field length constraint 
- Swagger UI for easy API exploration
- Unit tests with xUnit and Moq
- Global exception handling

## Requirements

- .NET 8.0 SDK or later
- Visual Studio 2022 or later (or VS Code with C# support)

## How to Run

1. Unzip the submission.
2. Open the solution ('StudentRestAPI.sln') in Visual Studio.
3. Set the API project as the startup project.
4. Run the project.
5. Navigate to 'https://localhost:<port>/swagger/index.html' to explore the API.

## How to Test

1. Open the solution ('StudentRestAPI.sln') in Visual Studio.
2. Run all tests from the test project ('StudentRestAPI.Tests').

## API Endpoints

- Method: GET, Endpoint:/api/students, Description: Get all students  
- Method: GET, Endpoint:/api/students/{id}, Description: Get student by Id
- Method: POST, Endpoint:/api/students, Description: Create a new student
- Method: PUT, Endpoint:/api/students/{id}, Description: Update a student
- Method: DELETE, Endpoint:/api/students/{id}, Description: Delete a student 

## Optional Enhancements Included

- Global error handler via `UseExceptionHandler`
- Swagger documentation
- Model validation attributes
- Custom validation logic for fields (e.g., DOB, phone format, grade)
- Logging (added some to the controller, can add logging to global exception handler later)
- Persistence layer (currently uses in-memory only)
