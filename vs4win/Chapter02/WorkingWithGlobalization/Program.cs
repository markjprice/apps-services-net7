using System.Globalization; // CultureInfo

CultureInfo globalization = CultureInfo.CurrentCulture;
CultureInfo localization = CultureInfo.CurrentUICulture;

WriteLine("The current globalization culture is {0}: {1}",
  globalization.Name, globalization.DisplayName);

WriteLine("The current localization culture is {0}: {1}",
  localization.Name, localization.DisplayName);

WriteLine();
WriteLine("en-US: English (United States)");
WriteLine("da-DK: Danish (Denmark)");
WriteLine("fr-CA: French (Canada)");

Write("Enter an ISO culture code: ");
string? newCulture = ReadLine();

if (!string.IsNullOrEmpty(newCulture))
{
  CultureInfo ci = CultureInfo.GetCultureInfo(newCulture);

  // change the current cultures on the thread
  CultureInfo.CurrentCulture = ci;
  CultureInfo.CurrentUICulture = ci;
}

WriteLine();
Write("Enter your name: ");
string name = ReadLine()!; // null-forgiving

Write("Enter your date of birth: ");
string dobText = ReadLine()!;

Write("Enter your salary: ");
string salaryText = ReadLine()!;

DateTime dob = DateTime.Parse(dobText);
int minutes = (int)DateTime.Today.Subtract(dob).TotalMinutes;
decimal salary = decimal.Parse(salaryText);

WriteLine(
  "{0} was born on a {1:dddd}, is {2:N0} minutes old, and earns {3:C}",
  name, dob, minutes, salary);
