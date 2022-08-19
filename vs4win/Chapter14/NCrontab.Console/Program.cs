using NCrontab;

DateTime start = new(2023, 1, 1);
DateTime end = start.AddYears(1);

WriteLine($"Start at:   {start:ddd, dd MMM yyyy HH:mm:ss}");
WriteLine($"End at:     {end:ddd, dd MMM yyyy HH:mm:ss}");
WriteLine();

string sec = "0";
string min = "0";
string hour = "4/3";
string dayOfMonth = "*";
string month = "*";
string dayOfWeek = "*";

string expression = string.Format(
  "{0,-3} {1,-3} {2,-3} {3,-3} {4,-3} {5,-3}",
  sec, min, hour, dayOfMonth, month, dayOfWeek);

CrontabSchedule schedule = CrontabSchedule.Parse(expression,
  new CrontabSchedule.ParseOptions { IncludingSeconds = true });

WriteLine($"Expression: {expression}");
WriteLine(@"            \ / \ / \ / \ / \ / \ /");
WriteLine($"             -   -   -   -   -   -");
WriteLine($"             |   |   |   |   |   |");
WriteLine($"             |   |   |   |   |   +--- day of week (0 - 6) (Sunday=0)");
WriteLine($"             |   |   |   |   +------- month (1 - 12)");
WriteLine($"             |   |   |   +----------- day of month (1 - 31)");
WriteLine($"             |   |   +--------------- hour (0 - 23)");
WriteLine($"             |   +------------------- min (0 - 59)");
WriteLine($"             +----------------------- sec (0 - 59)");
WriteLine();

IEnumerable<DateTime> occurrences = schedule.GetNextOccurrences(start, end);

// Output the first 40 occurrences.
foreach (DateTime occurrence in occurrences.Take(40))
{
  WriteLine($"{occurrence:ddd, dd MMM yyyy HH:mm:ss}");
}
