using AutoMapper; // MapperConfiguration
using MappingObjects.Mappers; // CartToSummaryMapper

namespace MappingObjects.Tests;

public class TestAutoMapperConfig
{
  [Fact]
  public void TestSummaryMapping()
  {
    MapperConfiguration config = CartToSummaryMapper.GetMapperConfiguration();

    config.AssertConfigurationIsValid();
  }
}