# FTDNA_Coding_Task
C# FTDNA Coding Task

Please complete this task using ASP.Net Core, ASP.NET Web API 2, Angular 2, and Entity Framework.

We ask that you return compilable code, and if it requires more than just building in VS to please include instructions on steps required.

## Testing

#### Assumptions
Default SQL Server connection in Data\FTDNAContext.cs: "Server=.;Database=FTDNADb;Integrated Security=True"

Create the database or change to applicable value. The database should have all of the seed data present in the text files here

#### Execute
Web API:

Use Visual Studio 2017 to open FTDNA_Coding_Task.sln to build and run

Or use cmd to execute the following
```
dotnet build
dotnet run
```
Application will be hosted at localhost:5000

User Interface:
```
cd wwwroot
npm install -g '@angular/cli'
npm install --production
npm start
```
Application will be hosted at localhost:4200
