# DogeNet
### Social network
This project is a social network for communication 
## Installation
1) Clone this solution to your computer
2) Open appsettings.json and change DBContext connection string to your target database
3) Open nuget package manager console and select DogeNet.DAL as target project and choose DogeNet.WebApi as startup project
4) Run Update-Database
## Tech stack
#### Backend:

ASP.NET Core 5.0

Swagger

#### ORM:

Entity Framework Core

#### DB server:

MSSQL Server 2019

#### Authorization:

Identity Server 4

Microsoft.Identity

Microsoft.Authorization

## Documentation
[Read the docs here](https://drive.google.com/drive/folders/1zzpCf84cFRVmDdqs30gMUUj0iQ1C03WU)
## Features
### Authorization
Identity Server, a separate centrilezed system of authorizing. All the services are authorized by it.
### Groups
### Profiles
### Messages
### Conversations
### Likes
### Comments
### Posts
