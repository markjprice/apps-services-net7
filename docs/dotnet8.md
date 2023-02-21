# First Edition's support for .NET 8

Microsoft will release previews of .NET 8 regularly starting in February 2023 until the final version on Tuesday, November 7, 2023.

- [Download .NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- November 7, 2023: Announcing .NET 8.0 - The Bestest .NET Yet
- October, 2023: [Announcing .NET 8 Release Candidate 2](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-rc-2/)
- September, 2023: [Announcing .NET 8 Release Candidate 1](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-rc-1/)
- August, 2023: [Announcing .NET 8 Preview 7](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-preview-7/)
- July, 2023: [Announcing .NET 8 Preview 6](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-preview-6/)
- June, 2023: [Announcing .NET 8 Preview 5](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-preview-5/)
- May, 2023: [Announcing .NET 8 Preview 4](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-preview-4/)
- April, 2023: [Announcing .NET 8 Preview 3](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-preview-3/)
- March, 2023: [Announcing .NET 8 Preview 2](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-preview-2/)
- February 21, 2023: [Announcing .NET 8 Preview 1](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-preview-1/)

## All Chapters

After [downloading](https://dotnet.microsoft.com/download/dotnet/8.0) and installing .NET 8.0 SDK, follow the step-by-step instructions in the book and they should work as expected since the project file will automatically reference .NET 8.0 as the target framework. 

To upgrade a project in the GitHub repository from .NET 7.0 to .NET 8.0 just requires a target framework change in your project file.

Change this:

```xml
<TargetFramework>net7.0</TargetFramework>
```

To this:

```xml
<TargetFramework>net8.0</TargetFramework>
```

For projects that reference additional NuGet packages, use the latest NuGet package version, as shown in the rest of this page, instead of the version given in the book. You can search for the correct NuGet package version numbers yourself at the following link: https://www.nuget.org

