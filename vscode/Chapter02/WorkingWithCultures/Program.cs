using Microsoft.Extensions.Hosting; // IHost, Host
// AddLocalization, AddTransient<T>
using Microsoft.Extensions.DependencyInjection;

// to enable special characters like €
OutputEncoding = System.Text.Encoding.Unicode;

using IHost host = Host.CreateDefaultBuilder(args)
  .ConfigureServices(services =>
  {
    services.AddLocalization(options =>
    {
      options.ResourcesPath = "Resources";
    });

    services.AddTransient<PacktResources>();
  })
  .Build();

OutputCultures("Default cultures");

WriteLine("en-US: English (United States) - default");
WriteLine("da-DK: Danish (Denmark)");
WriteLine("fr-CA: French (Canada)");
WriteLine();

Write("Enter an ISO culture code: ");
string? cultureCode = ReadLine();

if (string.IsNullOrWhiteSpace(cultureCode))
{
  cultureCode = "en-US";
}

CultureInfo ci;

try
{
  ci = CultureInfo.GetCultureInfo(cultureCode);
}
catch (CultureNotFoundException)
{
  WriteLine($"Culture code not found: {cultureCode}");
  return;
}

// change the current cultures on the thread
CultureInfo.CurrentCulture = ci;
CultureInfo.CurrentUICulture = ci;

OutputCultures("After changing cultures");

PacktResources resources =
    host.Services.GetRequiredService<PacktResources>();

Write(resources.GetEnterYourNamePrompt());
string? name = ReadLine();
if (string.IsNullOrWhiteSpace(name))
{
  name = "Bob";
}

Write(resources.GetEnterYourDobPrompt());
string? dobText = ReadLine();

if (string.IsNullOrWhiteSpace(dobText))
{
  dobText = "1/2/1990";
}

Write(resources.GetEnterYourSalaryPrompt());
string? salaryText = ReadLine();

if (string.IsNullOrWhiteSpace(salaryText))
{
  salaryText = "34500";
}

DateTime dob = DateTime.Parse(dobText);
int minutes = (int)DateTime.Today.Subtract(dob).TotalMinutes;
decimal salary = decimal.Parse(salaryText);

WriteLine(resources.GetPersonDetails(name, dob, minutes, salary));
