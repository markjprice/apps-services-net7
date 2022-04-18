using AutoMapper;
using Packt.Entities;
using Packt.ViewModels;

namespace MappingObjects.Tests
{
  public class TestAutoMapperConfig
  {
    [Fact]
    public void TestSummaryMapping()
    {
      MapperConfiguration config = new(cfg =>
      {
        cfg.CreateMap<Cart, Summary>()
          .ForMember(dest => dest.FullName, opt => opt.MapFrom(src =>
            string.Format("{0} {1}", 
              src.Customer.FirstName, src.Customer.LastName)
          ))
          .ForMember(dest => dest.Total, opt => opt.MapFrom(
            src => src.Items.Sum(item => item.UnitPrice * item.Quantity)));
      }
      );

      config.AssertConfigurationIsValid();
    }
  }
}