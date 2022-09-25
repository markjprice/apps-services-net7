- [Chapter 1 - Introducing Apps and Services with .NET](#chapter-1---introducing-apps-and-services-with-net)
  - [Visual Studio 2022 for Windows](#visual-studio-2022-for-windows)
  - [Visual Studio Code](#visual-studio-code)
  - [Other C# code editors and platforms](#other-c-code-editors-and-platforms)
  - [Command Line Interfaces](#command-line-interfaces)
  - [.NET](#net)
  - [C# language version and the journey to C# 11](#c-language-version-and-the-journey-to-c-11)
  - [C# implemented proposals](#c-implemented-proposals)
  - [C# proposals being worked on](#c-proposals-being-worked-on)
  - [C# language](#c-language)
  - [Help and learning](#help-and-learning)
- [Chapter 2 - Managing Relational Data Using SQL Server](#chapter-2---managing-relational-data-using-sql-server)
  - [Microsoft SQL Server](#microsoft-sql-server)
  - [EF Core](#ef-core)
  - [EF Core database providers](#ef-core-database-providers)
  - [EF Core models](#ef-core-models)
  - [EF Core querying and manipulating](#ef-core-querying-and-manipulating)
  - [Dapper and EF Core performance](#dapper-and-ef-core-performance)
- [Chapter 3 - Managing NoSQL Data Using Azure Cosmos DB](#chapter-3---managing-nosql-data-using-azure-cosmos-db)
  - [NoSQL data stores](#nosql-data-stores)
  - [Azure Cosmos DB](#azure-cosmos-db)
- [Chapter 4 - Improving Performance and Scalability Using Multitasking](#chapter-4---improving-performance-and-scalability-using-multitasking)
- [Chapter 5 - Using Popular Third-Party Libraries](#chapter-5---using-popular-third-party-libraries)
  - [Working with images](#working-with-images)
  - [Others](#others)
- [Chapter 6 - Controlling the Roslyn Compiler, Reflection and Expression Trees](#chapter-6---controlling-the-roslyn-compiler-reflection-and-expression-trees)
  - [Assemblies and reflection](#assemblies-and-reflection)
- [Chapter 7 - Handling Dates, Times, and Internationalization](#chapter-7---handling-dates-times-and-internationalization)
  - [Dates and times](#dates-and-times)
  - [Internationalization](#internationalization)
- [Chapter 8 - Protecting Your Data and Applications](#chapter-8---protecting-your-data-and-applications)
- [Chapter 9 - Building and Securing Web Services Using Minimal APIs](#chapter-9---building-and-securing-web-services-using-minimal-apis)
  - [Web service technologies](#web-service-technologies)
  - [Web Service design](#web-service-design)
  - [Web service routing](#web-service-routing)
  - [Web service clients](#web-service-clients)
  - [Documenting web services](#documenting-web-services)
  - [Securing web services](#securing-web-services)
  - [Security and privacy](#security-and-privacy)
  - [Health checks and reliable web services](#health-checks-and-reliable-web-services)
- [Chapter 10 - Exposing Data via the Web Using OData](#chapter-10---exposing-data-via-the-web-using-odata)
- [Chapter 11 - Combining Data Sources Using GraphQL](#chapter-11---combining-data-sources-using-graphql)
- [Chapter 12 - Building Efficient Microservices Using gRPC](#chapter-12---building-efficient-microservices-using-grpc)
- [Chapter 13 - Broadcasting Real-Time Communication Using SignalR](#chapter-13---broadcasting-real-time-communication-using-signalr)
- [Chapter 14 - Building Serverless Nanoservices Using Azure Functions](#chapter-14---building-serverless-nanoservices-using-azure-functions)
- [Chapter 15 - Building Web User Interfaces Using ASP.NET Core](#chapter-15---building-web-user-interfaces-using-aspnet-core)
  - [ASP.NET Core](#aspnet-core)
  - [Razor views and layouts](#razor-views-and-layouts)
- [Chapter 16 - Building Web Components Using Blazor WebAssembly](#chapter-16---building-web-components-using-blazor-webassembly)
  - [Blazor hosting models](#blazor-hosting-models)
  - [Blazor components](#blazor-components)
  - [Advanced techniques](#advanced-techniques)
- [Chapter 17 - Using Open-Source Blazor Component Libraries](#chapter-17---using-open-source-blazor-component-libraries)
  - [Blazor resources](#blazor-resources)
- [Chapter 18 - Building Mobile and Desktop Apps Using .NET MAUI](#chapter-18---building-mobile-and-desktop-apps-using-net-maui)
- [Chapter 19 - Integrating .NET MAUI Apps with Blazor and Native Platforms](#chapter-19---integrating-net-maui-apps-with-blazor-and-native-platforms)
- [Chapter 20 - Introducing the Survey Project Challenge](#chapter-20---introducing-the-survey-project-challenge)
- [Epilogue](#epilogue)
  - [Next steps on your C# and .NET learning journey](#next-steps-on-your-c-and-net-learning-journey)
  - [Learn from other Packt books](#learn-from-other-packt-books)

# Chapter 1 - Introducing Apps and Services with .NET

## Visual Studio 2022 for Windows
- Download Visual Studio for Windows: https://visualstudio.microsoft.com/downloads/
- Visual Studio for Windows documentation: https://docs.microsoft.com/en-us/visualstudio/windows/
- MSBuild and 64-bit Visual Studio 2022: https://devblogs.microsoft.com/dotnet/msbuild-and-64-bit-visual-studio-2022/

## Visual Studio Code
- Download Visual Studio Code: https://code.visualstudio.com/
- Set up Visual Studio Code: https://code.visualstudio.com/docs/setup/setup-overview
- Visual Studio Code user interface: https://code.visualstudio.com/docs/getstarted/userinterface
- Visual Studio Code support for C#: https://code.visualstudio.com/docs/languages/csharp
- Visual Studio Code key bindings and shortcuts: https://code.visualstudio.com/docs/getstarted/keybindings
  - Windows: https://code.visualstudio.com/shortcuts/keyboard-shortcuts-windows.pdf
  - macOS: https://code.visualstudio.com/shortcuts/keyboard-shortcuts-macos.pdf
  - Linux: https://code.visualstudio.com/shortcuts/keyboard-shortcuts-linux.pdf

## Other C# code editors and platforms
- Stack Overflow survey 2021 - Integrated development environment: https://insights.stackoverflow.com/survey/2021#section-most-popular-technologies-integrated-development-environment
- Stack Overflow survey 2019 - Most Popular Development Environments: https://insights.stackoverflow.com/survey/2019#development-environments-and-tools
- Visual Studio for Mac documentation: https://docs.microsoft.com/en-us/visualstudio/mac/
- GitHub Codespaces: https://docs.github.com/en/github/developing-online-with-codespaces/about-codespaces
- JetBrains Rider: https://www.jetbrains.com/rider/
- Rider documentation: https://www.jetbrains.com/help/rider/Introduction.html
- How to code with C# and .NET using a Raspberry Pi 400 with Ubuntu Desktop 64-bit by reading an extra article that I wrote at the following link: https://github.com/markjprice/cs9dotnet5-extras/blob/main/raspberry-pi-ubuntu64/README.md

## Command Line Interfaces
- Windows Terminal as your Default Command Line Experience: https://devblogs.microsoft.com/commandline/windows-terminal-as-your-default-command-line-experience/
- .NET Core Command-Line Interface (CLI) tool: https://aka.ms/dotnet-cli-docs

## .NET
- Download .NET SDK: https://www.microsoft.com/net/download
- Stack Overflow survey 2021 - Most loved frameworks and libraries: https://insights.stackoverflow.com/survey/2021#section-most-loved-dreaded-and-wanted-other-frameworks-and-libraries
- Themes of .NET: https://themesof.net/
- Official list of .NET 7 supported operating systems: https://github.com/dotnet/core/blob/main/release-notes/7.0/supported-os.md
- .NET Support Policy: https://dotnet.microsoft.com/platform/support/policy/dotnet-core
- .NET versions: https://docs.microsoft.com/en-us/dotnet/core/versions/
- .NET Uninstall Tool: https://docs.microsoft.com/en-us/dotnet/core/additional-tools/uninstall-tool
- Remove .NET SDKs and runtimes: https://docs.microsoft.com/en-us/dotnet/core/install/remove-runtime-sdk-versions
- .NET Core runtime, CoreCLR: https://github.com/dotnet/runtime
- .NET Core Roadmap: https://github.com/dotnet/core/blob/master/roadmap.md
- .NET Team Members: https://twitter.com/i/lists/120961876//members

## C# language version and the journey to C# 11
- Early peek at C# 11 features: https://devblogs.microsoft.com/dotnet/early-peek-at-csharp-11-features/
- What's new in C# 11: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-11
- What's new in C# 10: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-10
- What's new in C# 9.0: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9
- What's new in C# 8.0: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8
- What's new in C# 7.3: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-7-3
- Welcome to C# 10: https://devblogs.microsoft.com/dotnet/welcome-to-csharp-10/
- Rosalyn and C# compiler versions: https://github.com/dotnet/roslyn/blob/master/docs/wiki/NuGet-packages.md
- Current status of the C# language: https://github.com/dotnet/roslyn/blob/master/docs/Language%20Feature%20Status.md
- Draft proposals for C# Language Specifications for 6.0 and later: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/
- C# language versioning: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/configure-language-version
- [EPIC] .NET 6 C# project templates use latest language idioms #3359: https://github.com/dotnet/templating/issues/3359
- SDK support for implicit namespaces in C# projects #25066: https://github.com/dotnet/docs/issues/25066

## C# implemented proposals
- C# 10: https://github.com/dotnet/csharplang/tree/main/proposals/csharp-10.0
- C# 9: https://github.com/dotnet/csharplang/tree/main/proposals/csharp-9.0
- C# 8: https://github.com/dotnet/csharplang/tree/main/proposals/csharp-8.0
- C# 7.3: https://github.com/dotnet/csharplang/tree/main/proposals/csharp-7.3
- C# 7.2: https://github.com/dotnet/csharplang/tree/main/proposals/csharp-7.2
- C# 7.1: https://github.com/dotnet/csharplang/tree/main/proposals/csharp-7.1
- C# 7.0: https://github.com/dotnet/csharplang/tree/main/proposals/csharp-7.0
- C# 6.0: https://github.com/dotnet/csharplang/tree/main/proposals/csharp-6.0

## C# proposals being worked on
- [Proposal] Required Properties #3630: https://github.com/dotnet/csharplang/issues/3630
- Proposal: Semi-Auto-Properties; field keyword #140: https://github.com/dotnet/csharplang/issues/140
- Working Set (of proposals): https://github.com/dotnet/csharplang/milestone/19

## C# language
- C# Reference: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/
- C# Programming Guide: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/
- C# Keywords: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/index
- Naming guidelines: https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/naming-guidelines
- Types (C# Programming Guide): https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/
- Statements, Expressions, and Operators (C# Programming Guide): https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/

## Help and learning
- Raise an issue with the book: https://github.com/markjprice/apps-services-net7/issues
- Microsoft Docs: https://docs.microsoft.com/
- Official .NET Blog written by the .NET engineering teams: https://devblogs.microsoft.com/dotnet/
- Stack Overflow: https://stackoverflow.com/
- Google Advanced Search: https://www.google.com/advanced_search
- Microsoft Learn: https://docs.microsoft.com/en-us/learn/
- .NET Videos: https://dotnet.microsoft.com/learn/videos
- Microsoft Channel 9 – .NET Videos: https://channel9.msdn.com/Search?term=.net&lang-en=true

# Chapter 2 - Managing Relational Data Using SQL Server

## Microsoft SQL Server
- Try SQL Server on-premises or in the cloud: https://www.microsoft.com/en-us/sql-server/sql-server-downloads
- Download SQL Server Management Studio (SSMS): https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms
- Quickstart: Connect and query a SQL Server instance using SQL Server Management Studio (SSMS): https://docs.microsoft.com/en-us/sql/ssms/quickstarts/ssms-connect-query-sql-server
- Quickstart: Connect and query an Azure SQL Database or an Azure Managed Instance using SQL Server Management Studio (SSMS): https://docs.microsoft.com/en-us/sql/ssms/quickstarts/ssms-connect-query-azure-sql
- Use Visual Studio Code to create and run Transact-SQL scripts: https://docs.microsoft.com/en-us/sql/tools/visual-studio-code/sql-server-develop-use-vscode
- .NET Interactive with SQL!| .NET Notebooks in Visual Studio Code: https://devblogs.microsoft.com/dotnet/net-interactive-with-sql-net-notebooks-in-visual-studio-code/

## EF Core
- EF Core documentation: https://docs.microsoft.com/en-us/ef/core/
- EF Core team's plans: https://docs.microsoft.com/en-us/ef/core/what-is-new/ef-core-5.0/plan
- New features in EF Core 5: https://docs.microsoft.com/en-us/ef/core/what-is-new/ef-core-5.0/whatsnew
- New features in EF Core 6: https://docs.microsoft.com/en-us/ef/core/what-is-new/ef-core-6.0/whatsnew
- Get to Know EF Core 6: https://devblogs.microsoft.com/dotnet/get-to-know-ef-core-6/
- Announcing the Plan for EF7: https://devblogs.microsoft.com/dotnet/announcing-the-plan-for-ef7/
- Plans for Entity Framework Core 6.0 revealed as Microsoft admits it is unlikely to match Dapper for performance: https://www.theregister.com/2021/01/19/entity_framework_core_6/
- Entity Framework Community Standup - Performance Tuning an EF Core App: https://www.youtube.com/watch?v=VgNFFEqwZPU

## EF Core database providers
- EF Core database providers: https://docs.microsoft.com/en-us/ef/core/providers/
- Devart database providers: https://www.devart.com/dotconnect/entityframework.html
- Check the latest NuGet package version: https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Sqlite/
- Document Database Providers for Entity Framework Core: https://github.com/BlueshiftSoftware/EntityFrameworkCore

## EF Core models
- EF Core model conventions: https://docs.microsoft.com/en-us/ef/core/modeling/
- Data seeding: https://docs.microsoft.com/en-us/ef/core/modeling/data-seeding
- Humanizer library: http://humanizr.net
- Scaffolding: https://docs.microsoft.com/en-us/ef/core/managing-schemas/scaffolding?tabs=dotnet-core-cli
- Deep Dive into Many-to-Many: A Tour of EF Core 5.0: https://channel9.msdn.com/Shows/On-NET/Deep-Dive-into-Many-to-Many-A-Tour-of-EF-Core-50-pt-2
- Naming Conventions for Entity Framework Core Tables and Columns: https://github.com/efcore/EFCore.NamingConventions

## EF Core querying and manipulating
- Filtered include: https://docs.microsoft.com/en-us/ef/core/querying/related-data/eager#filtered-include
- Simple logging: https://docs.microsoft.com/en-us/ef/core/logging-events-diagnostics/simple-logging
- Query tags: https://docs.microsoft.com/en-us/ef/core/querying/tags
- Loading patterns: https://docs.microsoft.com/en-us/ef/core/querying/related-data
- Pooling database contexts: https://docs.microsoft.com/en-us/ef/core/what-is-new/ef-core-2.0#dbcontext-pooling

## Dapper and EF Core performance
- Dapper: https://github.com/DapperLib/Dapper
- Announcing Entity Framework Core 6.0 Preview 4: Performance Edition: https://devblogs.microsoft.com/dotnet/announcing-entity-framework-core-6-0-preview-4-performance-edition/
- Announcing Entity Framework Core 7 Preview 6: Performance Edition: https://devblogs.microsoft.com/dotnet/announcing-ef-core-7-preview6-performance-optimizations/

# Chapter 3 - Managing NoSQL Data Using Azure Cosmos DB

## NoSQL data stores
- Use NoSQL databases as a persistence infrastructure: https://docs.microsoft.com/en-us/dotnet/standard/microservices-architecture/microservice-ddd-cqrs-patterns/nosql-database-persistence-infrastructure

## Azure Cosmos DB
- Welcome to Azure Cosmos DB: https://docs.microsoft.com/en-us/azure/cosmos-db/introduction
- Azure Cosmos DB .NET SDK v3 for SQL API: Download and release notes: https://docs.microsoft.com/en-us/azure/cosmos-db/sql/sql-api-sdk-dotnet-standard
- Data modeling in Azure Cosmos DB: https://docs.microsoft.com/en-us/azure/cosmos-db/sql/modeling-data
- How to model and partition data on Azure Cosmos DB using a real-world example: https://docs.microsoft.com/en-us/azure/cosmos-db/sql/how-to-model-partition-example
- Getting started with SQL queries: https://docs.microsoft.com/en-us/azure/cosmos-db/sql/sql-query-getting-started
- Azure Cosmos DB query cheat sheets: https://docs.microsoft.com/en-us/azure/cosmos-db/sql/query-cheat-sheet
- Stored procedures, triggers, and user-defined functions: https://docs.microsoft.com/en-us/azure/cosmos-db/sql/stored-procedures-triggers-udfs
- Manage consistency levels in Azure Cosmos DB: https://docs.microsoft.com/en-us/azure/cosmos-db/sql/how-to-manage-consistency
- Create a container in Azure Cosmos DB SQL API: https://docs.microsoft.com/en-us/azure/cosmos-db/sql/how-to-create-container
- Query an Azure Cosmos container: https://docs.microsoft.com/en-us/azure/cosmos-db/sql/how-to-query-container
- Best practices for Azure Cosmos DB .NET SDK: https://docs.microsoft.com/en-us/azure/cosmos-db/sql/best-practice-dotnet
- Diagnose and troubleshoot issues when using Azure Cosmos DB .NET SDK: https://docs.microsoft.com/en-us/azure/cosmos-db/sql/troubleshoot-dot-net-sdk
- Migrate one-to-few relational data into Azure Cosmos DB SQL API account: https://docs.microsoft.com/en-us/azure/cosmos-db/sql/migrate-relational-to-cosmos-db-sql-api
- Frequently asked questions about different APIs in Azure Cosmos DB: https://docs.microsoft.com/en-us/azure/cosmos-db/faq

# Chapter 4 - Improving Performance and Scalability Using Multitasking

- Thread pool: https://docs.microsoft.com/en-us/dotnet/standard/threading/the-managed-thread-pool
- Pros and cons of different ways to start tasks: https://devblogs.microsoft.com/pfxteam/task-factory-startnew-vs-new-task-start/
- Events and thread-safety: https://docs.microsoft.com/en-us/archive/blogs/cburrows/field-like-events-considered-harmful
- Stephen Cleary's thoughts on events and thread-safety: https://blog.stephencleary.com/2009/06/threadsafe-events.html
- Threads and threading: https://docs.microsoft.com/en-us/dotnet/standard/threading/threads-and-threading
- Async in depth: https://docs.microsoft.com/en-us/dotnet/standard/async-in-depth
- await (C# reference): https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/await
- Parallel Programming in .NET: https://docs.microsoft.com/en-us/dotnet/standard/parallel-programming/
- Overview of synchronization primitives: https://docs.microsoft.com/en-us/dotnet/standard/threading/overview-of-synchronization-primitives

# Chapter 5 - Using Popular Third-Party Libraries

## Working with images
- ImageSharp: https://github.com/SixLabors/ImageSharp

## Others
- AutoMapper, a convention-based object-object mapper: https://automapper.org

# Chapter 6 - Controlling the Roslyn Compiler, Reflection and Expression Trees

## Assemblies and reflection
- .NET API Reference: https://docs.microsoft.com/en-us/dotnet/api/
- Compiler-generated display class: http://stackoverflow.com/a/2509524/55847
- Dynamically load assemblies that are not currently referenced: https://docs.microsoft.com/en-us/dotnet/standard/assembly/unloadability-howto
- Dynamically execute code: https://docs.microsoft.com/en-us/dotnet/api/system.reflection.methodbase.invoke
- Dynamically generate new code and assemblies: https://docs.microsoft.com/en-us/dotnet/api/system.reflection.emit.assemblybuilder
- Extending Metadata Using Attributes: https://docs.microsoft.com/en-us/dotnet/standard/attributes/

# Chapter 7 - Handling Dates, Times, and Internationalization

## Dates and times
- Date, Time, and Time Zone Enhancements in .NET 6: https://devblogs.microsoft.com/dotnet/date-time-and-time-zone-enhancements-in-net-6/
- .NET 6: Date and Time Structures: https://www.infoq.com/news/2021/04/Net6-Date-Time/
- Noda Time: A better date and time API for .NET: https://nodatime.org/

## Internationalization
- Globalizing and localizing .NET applications: https://docs.microsoft.com/en-us/dotnet/standard/globalization-localization/
- Time zones: https://devblogs.microsoft.com/dotnet/cross-platform-time-zones-with-net-core/

# Chapter 8 - Protecting Your Data and Applications

- Features supported by which OS: https://docs.microsoft.com/en-us/dotnet/standard/security/cross-platform-cryptography
- Dictionary Attacks 101: https://blog.codinghorror.com/dictionary-attacks-101/
- The first publicly known SHA1 collision happened in 2017: https://arstechnica.co.uk/information-technology/2017/02/at-deaths-door-for-years-widely-used-sha1-function-is-now-dead/
- The RSA algorithm is based on the factorization of large integers: http://mathworld.wolfram.com/RSAEncryption.html
- Key Security Concepts: https://docs.microsoft.com/en-us/dotnet/standard/security/key-security-concepts
- Encrypting Data: https://docs.microsoft.com/en-us/dotnet/standard/security/encrypting-data
- Cryptographic Signatures: https://docs.microsoft.com/en-us/dotnet/standard/security/cryptographic-signatures

# Chapter 9 - Building and Securing Web Services Using Minimal APIs

## Web service technologies
- Media types: http://en.wikipedia.org/wiki/Media_type
- WS-* standards: https://en.wikipedia.org/wiki/List_of_web_service_specifications
- HTTP OPTIONS method and other HTTP methods: https://developer.mozilla.org/en-US/docs/Web/HTTP/Methods/OPTIONS
- HTTP POST requests: https://developer.mozilla.org/en-US/docs/Web/HTTP/Methods/POST
- Create web APIs with ASP.NET Core: https://docs.microsoft.com/en-us/aspnet/core/web-api/

## Web Service design
- RESTful web API design: https://docs.microsoft.com/en-us/azure/architecture/best-practices/api-design

## Web service routing
- Design decisions around endpoint routing: https://devblogs.microsoft.com/aspnet/asp-net-core-2-2-0-preview1-endpoint-routing/
- Endpoint routing: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/routing
- Previous routing system: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/routing?view=aspnetcore-2.1
- Route constraints: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/routing#route-constraint-reference
- Dependency injection for ASP.NET Core: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection
- Proposed standard for Problem Details for HTTP APIs: https://tools.ietf.org/html/rfc7807
- Implementing problem details: https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.problemdetails

## Web service clients
- REST Client: https://github.com/Huachao/vscode-restclient/blob/master/README.md
- It is the BaseAddress and DefaultRequestHeaders properties that you should treat with caution with multiple threads: https://medium.com/@nuno.caneco/c-httpclient-should-not-be-disposed-or-should-it-45d2a8f568bc
- You're using HttpClient wrong and it is destabilizing your software: https://aspnetmonsters.com/2016/08/2016-08-27-httpclientwrong/
- How to initiate HTTP requests: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/http-requests
- Issues with the original HttpClient class available in .NET: https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests#issues-with-the-original-httpclient-class-available-in-net
- HttpClient extension methods for easily working with JSON: https://github.com/dotnet/designs/blob/main/accepted/2020/json-http-extensions/json-http-extensions.md

## Documenting web services
- Swagger: https://swagger.io/
- Swagger Tools: https://swagger.io/tools/
- Swashbuckle for ASP.NET Core: https://github.com/domaindrivendev/Swashbuckle.AspNetCore
- How Swagger can support multiple versions of an API: https://stackoverflow.com/questions/30789045/leverage-multipleapiversions-in-swagger-with-attribute-versioning/30789944
- Importance of documenting services: https://idratherbewriting.com/learnapidoc/
- Benefits of setting version compatibility: https://docs.microsoft.com/en-us/aspnet/core/mvc/compatibility-version
- Check latest version of analyzers package: http://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Api.Analyzers/

## Securing web services
- Verifying that the tokens used to call your web APIs are requested with the expected claims: https://docs.microsoft.com/en-us/azure/active-directory/develop/scenario-protected-web-api-verification-scope-app-roles
- CORS can be enabled to allow different origin requests: https://docs.microsoft.com/en-us/aspnet/core/security/cors
- Common HTTP security headers that you might want to add: https://www.meziantou.net/security-headers-in-asp-net-core.htm

## Security and privacy
- Built-in features for compliance with modern privacy requirements like GDPR: https://docs.microsoft.com/en-us/aspnet/core/security/gdpr
- ASP.NET Core's support for authenticator apps: https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity-enable-qrcodes
- Identity UI library: https://docs.microsoft.com/en-us/aspnet/core/security/authentication/scaffold-identity?tabs=netcore-cli
- Authorization: https://docs.microsoft.com/en-us/aspnet/core/security/authorization/introduction
- Anti-forgery tokens: https://docs.microsoft.com/en-us/aspnet/core/security/anti-request-forgery

## Health checks and reliable web services
- Health checks in ASP.NET Core: https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/health-checks
- How to extend the health check response: https://blogs.msdn.microsoft.com/webdev/2018/08/22/asp-net-core-2-2-0-preview1-healthcheck/
- How Polly can make your web services more reliable: https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/implement-http-call-retries-exponential-backoff-polly
- Use HttpClientFactory to implement resilient HTTP requests: https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests
- Redis: https://redis.io

# Chapter 10 - Exposing Data via the Web Using OData

- OData - the best way to REST: https://www.odata.org/
- Welcome to OData: https://docs.microsoft.com/en-us/odata/overview
- OData reference: https://docs.microsoft.com/en-us/dotnet/api/overview/odata-dotnet/
- OData DevBlog: https://devblogs.microsoft.com/odata/
- $compute and $search in ASP.NET Core OData 8: https://devblogs.microsoft.com/odata/compute-and-search-in-asp-net-core-odata-8/
- The Future of OData NxT (Neo): https://devblogs.microsoft.com/odata/the-future-of-odata-odata-nxt/
- API versioning extension with ASP.NET Core OData 8: https://devblogs.microsoft.com/odata/api-versioning-extension-with-asp-net-core-odata-8/

# Chapter 11 - Combining Data Sources Using GraphQL

- GraphQL: https://graphql.org/
- HotChocolate - ChilliCream GraphQL Platform: https://chillicream.com/docs/hotchocolate
- HotChocolate GitHub repository: https://github.com/ChilliCream/hotchocolate
- Getting started with GraphQL and HotChocolate: https://docs.microsoft.com/en-us/shows/on-net/getting-started-with-hotchocolate
- Say hello to Hot Chocolate 12!: https://chillicream.com/blog/2021/09/27/hot-chocolate-12

# Chapter 12 - Building Efficient Microservices Using gRPC

- gRPC: https://grpc.io/
- gRPC - Architecting Cloud Native .NET Applications for Azure: https://docs.microsoft.com/en-us/dotnet/architecture/cloud-native/grpc
- Introduction to gRPC on .NET: https://docs.microsoft.com/en-us/aspnet/core/grpc/
- Protocol Buffers: https://developers.google.com/protocol-buffers/docs/overview
- ASP.NET Core gRPC for WCF Developers: https://docs.microsoft.com/en-us/dotnet/architecture/grpc-for-wcf-developers/
- Introduction to HTTP/2: https://web.dev/performance-http2/

# Chapter 13 - Broadcasting Real-Time Communication Using SignalR

- Overview of ASP.NET Core SignalR: https://docs.microsoft.com/en-us/aspnet/core/signalr/introduction
- SignalR GitHub repository: https://github.com/dotnet/aspnetcore/tree/main/src/SignalR
- Azure SignalR Service: https://azure.microsoft.com/en-gb/services/signalr-service/

# Chapter 14 - Building Serverless Nanoservices Using Azure Functions

- Azure Functions: https://azure.microsoft.com/en-us/services/functions/
- Azure Functions documentation: https://docs.microsoft.com/en-us/azure/azure-functions/
- Azure serverless community library: https://www.serverlesslibrary.net/
- Quartz.NET: https://www.quartz-scheduler.net/
- Quartz.NET GitHub repository: https://github.com/quartznet/quartznet

# Chapter 15 - Building Web User Interfaces Using ASP.NET Core

## ASP.NET Core
- ASP.NET Core fundamentals: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/
- Overview of ASP.NET Core MVC: https://docs.microsoft.com/en-us/aspnet/core/mvc/overview
- Free TLS/SSL certificates: https://letsencrypt.org

## Razor views and layouts
- Razor syntax reference for ASP.NET Core: https://docs.microsoft.com/en-us/aspnet/core/mvc/views/razor
- HtmlHelper class: https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.viewfeatures.htmlhelper
- Views in ASP.NET Core MVC: https://docs.microsoft.com/en-us/aspnet/core/mvc/views/overview
- Layout in ASP.NET Core: https://docs.microsoft.com/en-us/aspnet/core/mvc/views/layout
- Tag Helpers in ASP.NET Core: https://docs.microsoft.com/en-us/aspnet/core/mvc/views/tag-helpers/intro
- ASP.NET Core Razor Pages with EF Core: https://docs.microsoft.com/en-us/aspnet/core/data/ef-rp/intro
- Registering a database context for use as a dependency service: https://docs.microsoft.com/en-us/ef/core/miscellaneous/configuring-dbcontext#using-dbcontext-with-dependency-injection
- The `<partial>` tag helper: https://docs.microsoft.com/en-us/aspnet/core/mvc/views/tag-helpers/built-in/partial-tag-helper
- Why it is good to put <script> elements at the bottom of the <body>: https://stackoverflow.com/questions/436411/where-should-i-put-script-tags-in-html-markup

# Chapter 16 - Building Web Components Using Blazor WebAssembly

## Blazor hosting models
- Blazor: https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor
- Official list of supported Blazor platforms: https://docs.microsoft.com/en-us/aspnet/core/blazor/supported-platforms
- Blazor hosting models: https://docs.microsoft.com/en-us/aspnet/core/blazor/hosting-models
- Blazor Hybrid apps: https://devblogs.microsoft.com/aspnet/hybrid-blazor-apps-in-mobile-blazor-bindings-july-update/

## Blazor components
- The reason for needing CSS isolation for Blazor components: https://github.com/dotnet/aspnetcore/issues/10170
- OI icons: https://iconify.design/icon-sets/oi/
- Control <head> content in ASP.NET Core Blazor apps: https://learn.microsoft.com/en-us/aspnet/core/blazor/components/control-head-content
- Forms and validation: https://docs.microsoft.com/en-us/aspnet/core/blazor/forms-validation
- NavigationManager with Blazor routes: https://docs.microsoft.com/en-us/aspnet/core/blazor/fundamentals/routing#uri-and-navigation-state-helpers

## Advanced techniques
- Implementing offline support for Blazor WebAssembly projects: https://docs.microsoft.com/en-us/aspnet/core/blazor/progressive-web-app#offline-support
- Lazy loading assemblies: https://docs.microsoft.com/en-us/aspnet/core/blazor/webassembly-lazy-load-assemblies?view=aspnetcore-5.0
- Routing in Blazor Apps: Comparing the routing of popular web frameworks like React and Angular with Blazor: https://devblogs.microsoft.com/premier-developer/routing-in-blazor-apps/

# Chapter 17 - Using Open-Source Blazor Component Libraries

## Blazor resources
- Awesome Blazor: A collection of awesome Blazor resources: https://github.com/AdrienTorris/awesome-blazor
- Blazor University: Learn the new .NET SPA framework from Microsoft: https://blazor-university.com
- Blazor - app building workshop: In this workshop, we will build a complete Blazor app and learn about the various Blazor framework features along the way: https://github.com/dotnet-presentations/blazor-workshop/
- Carl Franklin's Blazor Train: https://www.youtube.com/playlist?list=PL8h4jt35t1wjvwFnvcB2LlYL4jLRzRmoz
- Welcome to PACMAN written in C# and running on Blazor WebAssembly: https://github.com/SteveDunn/PacManBlazor

# Chapter 18 - Building Mobile and Desktop Apps Using .NET MAUI

- .NET Multi-platform App UI: https://dotnet.microsoft.com/en-us/apps/maui
- .NET Multi-platform App UI documentation: https://docs.microsoft.com/en-us/dotnet/maui/
- .NET Multi-platform App UI (.NET MAUI) Support Policy: https://dotnet.microsoft.com/en-us/platform/support/policy/maui
- .NET Podcasts - Sample Application: https://github.com/microsoft/dotnet-podcasts
- Visual Studio 2022 for Mac is now available: https://devblogs.microsoft.com/visualstudio/visual-studio-2022-for-mac-is-now-available/
- Introducing .NET MAUI – One Codebase, Many Platforms: https://devblogs.microsoft.com/dotnet/introducing-dotnet-maui-one-codebase-many-platforms/
- Introducing .NET Multi-platform App UI: https://devblogs.microsoft.com/dotnet/introducing-net-multi-platform-app-ui/
- Layouts: https://docs.microsoft.com/en-us/dotnet/maui/user-interface/layouts/
- Pages - ContentPage: https://docs.microsoft.com/en-us/dotnet/maui/user-interface/pages/contentpage
- Add a splash screen to a .NET MAUI app project: https://docs.microsoft.com/en-us/dotnet/maui/user-interface/images/splashscreen
- Inspect the visual tree of a .NET MAUI app: https://docs.microsoft.com/en-us/dotnet/maui/user-interface/live-visual-tree
- Phone dialer: https://docs.microsoft.com/en-us/dotnet/maui/platform-integration/communication/phone-dialer
- Connect to local web services from Android emulators and iOS simulators: https://docs.microsoft.com/en-us/dotnet/maui/data-cloud/local-web-services
- .NET MAUI - Workshop: https://github.com/dotnet-presentations/dotnet-maui-workshop
- Build mobile and desktop apps with .NET MAUI learning path: https://docs.microsoft.com/en-gb/learn/paths/build-apps-with-dotnet-maui/
- Forums: https://docs.microsoft.com/en-us/answers/topics/dotnet-maui.html

# Chapter 19 - Integrating .NET MAUI Apps with Blazor and Native Platforms

- Host a Blazor web app in a .NET MAUI app using BlazorWebView: https://docs.microsoft.com/en-us/dotnet/maui/user-interface/controls/blazorwebview
- Enterprise Application Patterns Using .NET MAUI: https://docs.microsoft.com/en-us/dotnet/architecture/maui/
- CarouselView: https://docs.microsoft.com/en-us/dotnet/maui/user-interface/controls/carouselview/
- Display a menu bar in a .NET MAUI desktop app: https://docs.microsoft.com/en-us/dotnet/maui/user-interface/menubar
- Xamarin.Essentials 1.7 and introducing .NET MAUI Essentials: https://devblogs.microsoft.com/xamarin/xamarin-essentials-1-7-and-introducing-net-maui-essentials/
- Platform integration: https://docs.microsoft.com/en-us/dotnet/maui/platform-integration/
- Permissions: https://docs.microsoft.com/en-us/dotnet/maui/platform-integration/appmodel/permissions
- Connectivity: https://docs.microsoft.com/en-us/dotnet/maui/platform-integration/communication/networking
- Device information: https://docs.microsoft.com/en-us/dotnet/maui/platform-integration/device/information
- Geolocation: https://docs.microsoft.com/en-us/dotnet/maui/platform-integration/device/geolocation
- App actions: https://docs.microsoft.com/en-us/dotnet/maui/platform-integration/appmodel/app-actions
- File picker: https://docs.microsoft.com/en-us/dotnet/maui/platform-integration/storage/file-picker
- Media picker: https://docs.microsoft.com/en-us/dotnet/maui/platform-integration/device-media/picker
- Clipboard: https://docs.microsoft.com/en-us/dotnet/maui/platform-integration/data/clipboard
- Secure storage: https://docs.microsoft.com/en-us/dotnet/maui/platform-integration/storage/secure-storage

# Chapter 20 - Introducing the Survey Project Challenge

# Epilogue

## Next steps on your C# and .NET learning journey
- Follow the Framework Design Guidelines: https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/
- Follow the code style rules: https://docs.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/
- Cloud-Native learning resources for .NET developers: https://devblogs.microsoft.com/dotnet/cloud-native-learning-resources-for-net-developers/

## Learn from other Packt books
- Mobile Development with .NET: https://www.packtpub.com/product/mobile-development-with-net-second-edition/9781800204690
- Enterprise Application Development with C# 9 and .NET 5: https://www.packtpub.com/product/enterprise-application-development-with-c-9-and-net-5/9781800209442
- Software Architecture with C# 9 and .NET 5: https://www.packtpub.com/product/software-architecture-with-c-9-and-net-5-second-edition/9781800566040
- An Atypical ASP.NET Core 5 Design Patterns Guide: https://www.packtpub.com/product/an-atypical-asp-net-core-5-design-patterns-guide/9781789346091
- Customizing ASP.NET Core 5.0: https://www.packtpub.com/product/customizing-asp-net-core-5-0/9781801077866
- ASP.NET Core Secure Coding Cookbook: https://www.packtpub.com/product/asp-net-core-secure-coding-cookbook/9781801071567
- ASP.NET Core 5 and React: https://www.packtpub.com/product/asp-net-core-5-and-react-second-edition/9781800206168
- ASP.NET Core 5 and Angular: https://www.packtpub.com/product/asp-net-core-5-and-angular-fourth-edition/9781800560338
- ASP.NET Core and Vue.js: https://www.packtpub.com/product/asp-net-core-and-vue-js/9781800206694
- Practical Microservices with Dapr and .NET: https://www.packtpub.com/product/practical-microservices-with-dapr-and-net/9781800568372
- Web Development with Blazor and .NET 5: https://www.packtpub.com/product/web-development-with-blazor-and-net-5/9781800208728
- Mastering Windows Presentation Foundation: https://www.packtpub.com/product/mastering-windows-presentation-foundation-second-edition/9781838643416
