partial class Program
{
  static void OutputCultures(string title)
  {
    ConsoleColor previousColor = ForegroundColor;
    ForegroundColor = ConsoleColor.DarkYellow;

    WriteLine("*");
    WriteLine($"* {title}");
    WriteLine("*");

    // get the cultures from the current thread
    CultureInfo globalization = CultureInfo.CurrentCulture;
    CultureInfo localization = CultureInfo.CurrentUICulture;

    WriteLine("The current globalization culture is {0}: {1}",
      globalization.Name, globalization.DisplayName);

    WriteLine("The current localization culture is {0}: {1}",
      localization.Name, localization.DisplayName);

    WriteLine("Days of the week: {0}",
      string.Join(", ", globalization.DateTimeFormat.DayNames));

    WriteLine("Number group separator: {0}",
      globalization.NumberFormat.NumberGroupSeparator);

    WriteLine("Number decimal separator: {0}",
      globalization.NumberFormat.NumberDecimalSeparator);

    WriteLine();

    ForegroundColor = previousColor;
  }
}
