# Task Management application API build with ASP.NET CORE 9

## A fully functional Task Management management API showing how to create a REST API

The project was created as part of an assignement to create a Task Management Application A task management application created using ASP.NET Core and following the CQRS clean architecture.
The following features are included

* User management REST interface allowing new registration and login
* JWT for authentication and authorisation. Generates an access token that can be further used to access the secure endpoints
* Task Management REST endpoints, secured endpoints that user can use to manage task i.e CRUD (Create, Read, Update, Delete)

## Tech stack used

* Visual Studio 2022
* .NET 9
* .SQL Server

## How to install the task management project on local machine

This can be done by
1. Clone this project
2. Make sure you have the following installed
   a. VSCODE or Visual Studio 2022.
   c Instal the latest version of ASP.Net Core (.Net 9 at the time of writing)
   b. Microsoft SQL Server / SQL Server Lite
3. Update database connection string in the appsetting file to point to SQL Server on your local machine
4. Generate database and initial seed data. This is done by making use of Microsoft Nuget package EntityframeworkCore as an Object Relation Mapping (ORM) tool by enable and executing migrations

## Find a bug?

If you found an issue or would like to submit an improvement to this project, please submit an issue using the issues tab above. If you would like to submit a PR fix, reference the issue you created!

## In Progress
The front end to consume the API is under development using the REACt Framework

   
