# StudentsWebApi 🧾
This project aims to obtain students information from the sqlLite.db sample.db3.

# Technologies 💻

* [.Net 6](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-6) - The web api framework used
* [EntityFramework](https://learn.microsoft.com/es-es/ef/) - Implementation of ORM with EntityFramework
* [SqLite - EF](https://learn.microsoft.com/es-es/ef/core/providers/sqlite/?tabs=dotnet-core-cli) - Implementation of SQLite database with SqLite - EF
* [Dapper](https://www.learndapper.com/) - Implementation of Micro ORM with Dapper
* [MediatR](https://github.com/jbogard/MediatR) - Implementation of CQRS Pattern with MediatR
* [AutoMapper](https://automapper.org/) - Implementation of Mapper Entities in Dtos with AutoMapper
 
## Getting started ✔️

These instructions will allow you to get a copy of the project up and running on your local machine for development and testing purposes.
See Installation to learn how to deploy the project.

## Prerequisites 📋

In order to run the project, it is necessary to have: 
  - Visual Studio 2022.
  - .Net 6

## Installation  🔧

_Download and install Visual studio 2022:_ ```[Visual Studio](https://visualstudio.microsoft.com/es/vs/)```

_Clone this repository:_ ```git clone https://github.com/fk-devops98/StudentsWebApi.git.```

_Open ```Students.sln``` from the root of the project._

_Advantage. 🎉

## Build 🚀

_Run ```build``` in the visual studio app._

## List of students
* Method: [GET]
* Url: (https://localhost:7065/api/students)

## New student
* Method: [POST]
* Url: (https://localhost:7065/api/students)
* Body: 
  - **Username**
  - **FirstName**
  - **LastName**
  - **Age**
  - **Career**

## Update student
* Method: [PUT]
* Url: (https://localhost:7065/api/students/Id)
* Body: 
  - **Username**
  - **FirstName**
  - **LastName**
  - **Age**
  - **Career**

## Delete student
* Method: [DELETE]
* Url: (https://localhost:7065/api/students/Id)
