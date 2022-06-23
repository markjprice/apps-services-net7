partial class Program
{
  static void MethodA()
  {
    try
    {
      if (Monitor.TryEnter(SharedObjects.Conch, TimeSpan.FromSeconds(15)))
      {
        for (int i = 0; i < 5; i++)
        {
          Thread.Sleep(Random.Shared.Next(2000));
          SharedObjects.Message += "A";
          Interlocked.Increment(ref SharedObjects.Counter);
          Write(".");
        }
      }
      else
      {
        WriteLine("Method A timed out when entering a monitor on conch.");
      }
    }
    finally
    {
      Monitor.Exit(SharedObjects.Conch);
    }
  }

  static void MethodB()
  {
    try
    {
      if (Monitor.TryEnter(SharedObjects.Conch, TimeSpan.FromSeconds(15)))
      {
        for (int i = 0; i < 5; i++)
        {
          Thread.Sleep(Random.Shared.Next(2000));
          SharedObjects.Message += "B";
          Interlocked.Increment(ref SharedObjects.Counter);
          Write(".");
        }
      }
      else
      {
        WriteLine("Method B timed out when entering a monitor on conch.");
      }
    }
    finally
    {
      Monitor.Exit(SharedObjects.Conch);
    }
  }
}
