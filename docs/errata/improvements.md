**Improvements** (5 items)

If you have suggestions for improvements, then please [raise an issue in this repository](https://github.com/markjprice/apps-services-net7/issues) or email me at markjprice (at) gmail.com.

- [Page 72 - Executing stored procedures using ADO.NET](#page-72---executing-stored-procedures-using-adonet)
- [Page 81 - Defining the Northwind database model](#page-81---defining-the-northwind-database-model)
- [Page 232 - Making a type or member obsolete](#page-232---making-a-type-or-member-obsolete)
- [Page 326 - Setting up an ASP.NET Core Web API project](#page-326---setting-up-an-aspnet-core-web-api-project)
- [Page 362 - Building a web service that supports OData](#page-362---building-a-web-service-that-supports-odata)

# Page 72 - Executing stored procedures using ADO.NET

> Thanks to [Bob Molloy](https://github.com/BobMolloy) for raising this [issue on 31 December 2022](https://github.com/markjprice/apps-services-net7/issues/3).

In Step 2, I wrote, "In your preferred database tool, add a new stored procedure. For example, if you are using 
SQL Server Management Studio, then right-click Stored Procedures and select Add New Stored Procedure."

It would be better to add an extra step, "In your preferred database tool, add a new stored procedure. For example, if you are using SQL Server Management Studio, then **expand the Programmability node,** right-click Stored Procedures, and select Add New Stored Procedure."

# Page 81 - Defining the Northwind database model

> Thanks to [Bob Molloy](https://github.com/BobMolloy) for raising this [issue on 31 December 2022](https://github.com/markjprice/apps-services-net7/issues/4).

In Step 4, I show text that must be entered as a single line at the command-line, as shown in the following command formatted as in the print book:
```
dotnet ef dbcontext scaffold "Data Source=.;Initial 
Catalog=Northwind;Integrated Security=true;TrustServerCertificate=true;" 
Microsoft.EntityFrameworkCore.SqlServer --output-dir Models --namespace 
Northwind.Console.EFCore.Models --data-annotations --context NorthwindDb
```

I recommend that you type from the print book or copy and paste long commands like this from the eBook into a plain text editor like Notepad. Then make sure that the whole command is properly formatted as a single line with correct spacing, before you then copy and paste it to the command-line. Copying and pasting directly from the eBook is likely to include newline characters and missing spaces and so on that break the command.

For convenience, here is the same command as a single line to make it easier to copy and paste:
```
dotnet ef dbcontext scaffold "Data Source=.;Initial Catalog=Northwind;Integrated Security=true;TrustServerCertificate=true;" Microsoft.EntityFrameworkCore.SqlServer --output-dir Models --namespace Northwind.Console.EFCore.Models --data-annotations --context NorthwindDb
```

# Page 232 - Making a type or member obsolete

> Thanks to [Bob Molloy](https://github.com/BobMolloy) for raising this [issue on 14 January 2023](https://github.com/markjprice/apps-services-net7/issues/8).

Make sure you do not miss the addition of the `{3}` placeholder in the call to `WriteLine`! I will add a note to highlight this in the 8th edition.

# Page 326 - Setting up an ASP.NET Core Web API project

> Thanks to Bob Molloy for emailing me about this issue on 25 January 2023.

In Step 7, I wrote, "Start the website project using the `https` profile (`dotnet run --launch-profile https`) and 
note the Swagger documentation." This sentence was sloppily written and it did not include detailed instructions on how to start a website project or to start the web browser manually if using the command-line. In the next edition I will add more details.

For example, as always with starting a website project, if you use Visual Studio 2022 then it can automatically start a web browser for you if you have configured it to do so using the `launchSettings.json` file, as you did in Step 5, and as shown in the following configuration:
```json
"profiles": {
  ...
  "https": {
    "commandName": "Project",
    "dotnetRunMessages": true,
    "launchBrowser": true,
    "launchUrl": "swagger",
    "applicationUrl": "https://localhost:5091",
    "environmentVariables": {
    "ASPNETCORE_ENVIRONMENT": "Development"
  }
```
But if you start the website project at the command-line then you must manually start a web browser and manually navigate to `https://localhost:5091/swagger`.

# Page 362 - Building a web service that supports OData

> Thanks to Bob Molloy for emailing me about this issue on 5 January 2023.

In Step 3, you add a reference to a project that is outside the solution. In Step 4, you build the project at the command-line or terminal by using the following command: `dotnet build`. 

There is a note to explain that if you try to use the **Build** menu in Visual Studio then you will see an error. This is because Visual Studio cannot find projects that are outside a solution. In early drafts of the book, this was the first time this situation occurred which is why I put the note here. In later drafts, the SQL Server and Cosmos DB chapters were moved earlier. So then the first time the situation occurs is in Chapter 3 on page 130. In the next edition I will move the note to the first time the situation occurs.
