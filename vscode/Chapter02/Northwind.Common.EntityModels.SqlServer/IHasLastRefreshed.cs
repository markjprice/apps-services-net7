namespace Packt.Shared;

public interface IHasLastRefreshed
{
  DateTimeOffset LastRefreshed { get; set; }
}
