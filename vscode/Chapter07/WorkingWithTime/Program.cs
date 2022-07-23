using System.Globalization; // CultureInfo

SectionTitle("Specifying date and time values");

// optional: explicitly set culture to English (British)
Thread.CurrentThread.CurrentCulture = System.Globalization
  .CultureInfo.GetCultureInfo("en-GB");

WriteLine($"DateTime.MinValue:  {DateTime.MinValue}");
WriteLine($"DateTime.MaxValue:  {DateTime.MaxValue}");
WriteLine($"DateTime.UnixEpoch: {DateTime.UnixEpoch}");
WriteLine($"DateTime.Now:       {DateTime.Now}");
WriteLine($"DateTime.Today:     {DateTime.Today}");

DateTime xmas = new(year: 2024, month: 12, day: 25);
WriteLine($"Christmas (default format): {xmas}");
WriteLine($"Christmas (custom format): {xmas:dddd, dd MMMM yyyy}");
WriteLine($"Christmas is in month {xmas.Month} of the year.");
WriteLine($"Christmas is day {xmas.DayOfYear} of the year 2024.");
WriteLine($"Christmas {xmas.Year} is on a {xmas.DayOfWeek}.");

SectionTitle("Date and time calculations");

DateTime beforeXmas = xmas.Subtract(TimeSpan.FromDays(12));
DateTime afterXmas = xmas.AddDays(12);

// :d means format as short date only without time
WriteLine($"12 days before Christmas: {beforeXmas:d}");
WriteLine($"12 days after Christmas: {afterXmas:d}");

TimeSpan untilXmas = xmas - DateTime.Now;

WriteLine($"Now: {DateTime.Now}");
WriteLine("There are {0} days and {1} hours until Christmas 2024.",
  arg0: untilXmas.Days, arg1: untilXmas.Hours);

WriteLine("There are {0:N0} hours until Christmas.",
  arg0: untilXmas.TotalHours);

DateTime kidsWakeUp = new(
  year: 2024, month: 12, day: 25,
  hour: 6, minute: 30, second: 0);

WriteLine($"Kids wake up: {kidsWakeUp}");

WriteLine("The kids woke me up at {0}",
  arg0: kidsWakeUp.ToShortTimeString());

SectionTitle("Globalization with dates and times");

// same as Thread.CurrentThread.CurrentCulture
WriteLine($"Current culture is: {CultureInfo.CurrentCulture.Name}");

string textDate = "4 July 2024";
DateTime independenceDay = DateTime.Parse(textDate);

WriteLine($"Text: {textDate}, DateTime: {independenceDay:d MMMM}");

textDate = "7/4/2024";
independenceDay = DateTime.Parse(textDate);

WriteLine($"Text: {textDate}, DateTime: {independenceDay:d MMMM}");

independenceDay = DateTime.Parse(textDate,
  provider: CultureInfo.GetCultureInfo("en-US"));

WriteLine($"Text: {textDate}, DateTime: {independenceDay:d MMMM}");

for (int year = 2022; year <= 2028; year++)
{
  Write($"{year} is a leap year: {DateTime.IsLeapYear(year)}. ");
  WriteLine("There are {0} days in February {1}.",
    arg0: DateTime.DaysInMonth(year: year, month: 2), arg1: year);
}

WriteLine("Is Christmas daylight saving time? {0}",
  arg0: xmas.IsDaylightSavingTime());

WriteLine("Is July 4th daylight saving time? {0}",
  arg0: independenceDay.IsDaylightSavingTime());

SectionTitle("Working with only a date or a time");

DateOnly jubilee = new(year: 2022, month: 6, day: 4);
WriteLine($"The Queen's Platinum Jubilee is on {jubilee.ToLongDateString()}.");

TimeOnly partyStarts = new(hour: 16, minute: 30);
WriteLine($"The Queen's party starts at {partyStarts}.");

DateTime calendarEntry = jubilee.ToDateTime(partyStarts);
WriteLine($"Add to your calendar: {calendarEntry}.");
