# First Edition's support for .NET 8

Microsoft will release previews of .NET 8 monthly starting in February 2023 until the final General Availability (GA) version on Tuesday, November 7, 2023.

> [Download .NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

## .NET 8 Preview announcements

- February 21, 2023: [Announcing .NET 8 Preview 1](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-preview-1/)
- March 14, 2023: [Announcing .NET 8 Preview 2](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-preview-2/)
- April 11, 2023: [Announcing .NET 8 Preview 3](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-preview-3/)
- May 16, 2023: [Announcing .NET 8 Preview 4](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-preview-4/)
- June, 2023: [Announcing .NET 8 Preview 5](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-preview-5/)
- July, 2023: [Announcing .NET 8 Preview 6](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-preview-6/)
- August, 2023: [Announcing .NET 8 Preview 7](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-preview-7/)
- September, 2023: [Announcing .NET 8 Release Candidate 1](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-rc-1/)
- October, 2023: [Announcing .NET 8 Release Candidate 2](https://devblogs.microsoft.com/dotnet/announcing-dotnet-8-rc-2/)
- November 7, 2023: Announcing .NET 8.0 - The Bestest .NET Yet

## Visual Studio 2022 support

To use .NET 8 previews with Visual Studio 2022, you must install version 17.6 Preview 1 or later. 

> [Download Visual Studio Preview](https://visualstudio.microsoft.com/vs/preview/#download-preview)

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

