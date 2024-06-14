# PTKDotNetCore

<img src="https://github.com/devicons/devicon/blob/master/icons/csharp/csharp-original.svg" alt="csharp logo" width="40" height="40" />

- Console App
- Ado.Net
- Dapper
- EFCore
- ASP.NET Core Web API
- ASP.NET Core Web MVC
- truncate table Tbl_Blog //to restart the table data from 1
- to write c# code in javascript use @
 X Scaffold-DbContext "Server=.\SQLExpress;Database=SchoolDB;User Id=sa;Password=phyo@123;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
 X Scaffold-DbContext "Server=.\\MSSQLSERVER1;Database=TestDb ;User ID=sa;Password=phyo@123;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir EFCoreDataModels -Context AppDbContext -Tables Tbl_Blog
 Scaffold-DbContext "Server=.;Database=TestDb ;User ID=sa;Password=sasa@123;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir EFCoreDataModels -Context AppDbContext -Tables Tbl_Blog
 dotnet ef dbcontext scaffold "Server=.;Database=TestDb ;User ID=sa;Password=sasa@123;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models -c AppDbContext -t Tbl_Blog 