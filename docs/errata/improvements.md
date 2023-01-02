**Improvements** (2 items)

If you have suggestions for improvements, then please [raise an issue in this repository](https://github.com/markjprice/apps-services-net7/issues) or email me at markjprice (at) gmail.com.

- [Page 72 - Executing stored procedures using ADO.NET](#page-72---executing-stored-procedures-using-adonet)
- [Page 81 - Defining the Northwind database model](#page-81---defining-the-northwind-database-model)

# Page 72 - Executing stored procedures using ADO.NET

> Thanks to [Bob Molloy](https://github.com/BobMolloy) for raising this [issue on 31 December 2022](https://github.com/markjprice/apps-services-net7/issues/3).

In Step 2, I wrote, "In your preferred database tool, add a new stored procedure. For example, if you are using 
SQL Server Management Studio, then right-click Stored Procedures and select Add New Stored Procedure."

It would be better to add an extra step, "In your preferred database tool, add a new stored procedure. For example, if you are using SQL Server Management Studio, then **expand the Programmability node,** right-click Stored Procedures, and select Add New Stored Procedure."

# Page 81 - Defining the Northwind database model

> Thanks to [Bob Molloy](https://github.com/BobMolloy) for raising this [issue on 31 December 2022](https://github.com/markjprice/apps-services-net7/issues/4).

In Step 4, I show text that must be entered as a single line at the command-line, as shown in the following command:
```
dotnet ef dbcontext scaffold "Data Source=.;Initial 
Catalog=Northwind;Integrated Security=true;TrustServerCertificate=true;" 
Microsoft.EntityFrameworkCore.SqlServer --output-dir Models --namespace 
Northwind.Console.EFCore.Models --data-annotations --context NorthwindDb
```

I recommend that you copy and paste long commands like this from the ebook into a plain text editor like Notepad, and then make sure that the whole command is properly formatted as a single line, before you then copy and paste it to the command-line. 

Copying and pasting directly from the ebook is likely to include newline characters and missing spaces and so on that break the command.
