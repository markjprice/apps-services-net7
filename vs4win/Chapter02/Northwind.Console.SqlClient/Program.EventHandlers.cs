using Microsoft.Data.SqlClient; // SqlInfoMessageEventArgs
using System.Data; // StateChangeEventArgs

partial class Program
{
  static void Connection_StateChange(object sender, StateChangeEventArgs e)
  {
    ConsoleColor previousColor = ForegroundColor;
    ForegroundColor = ConsoleColor.DarkYellow;
    WriteLine($"State change from {e.OriginalState} to {e.CurrentState}.");
    ForegroundColor = previousColor;
  }

  static void Connection_InfoMessage(object sender, SqlInfoMessageEventArgs e)
  {
    ConsoleColor previousColor = ForegroundColor;
    ForegroundColor = ConsoleColor.DarkBlue;
    WriteLine($"Info: {e.Message}.");
    foreach (SqlError error in e.Errors)
    {
      WriteLine($"  Error: {error.Message}.");
    }
    ForegroundColor = previousColor;
  }
}
