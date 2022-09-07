using AutoMapper; // MapperConfiguration
using AutoMapper.Internal; // Internal() extension method
using Packt.Entities; // Cart
using Packt.ViewModels; // Summary

namespace MappingObjects.Mappers;

public static class CartToSummaryMapper
{
  public static MapperConfiguration GetMapperConfiguration()
  {
    MapperConfiguration config = new(cfg =>
    {
      // fix issue with .NET 7 Preview 5 and its new MaxInteger method
      // https://github.com/AutoMapper/AutoMapper/issues/3988
      cfg.Internal().MethodMappingEnabled = false;

      // configure mapper using projections

      cfg.CreateMap<Cart, Summary>()

        // FullName
        .ForMember(dest => dest.FullName, opt => opt.MapFrom(src =>
          string.Format("{0} {1}",
            src.Customer.FirstName,
            src.Customer.LastName)
        ))

        // Total
        .ForMember(dest => dest.Total, opt => opt.MapFrom(
          src => src.Items.Sum(item => item.UnitPrice * item.Quantity)));
    });

    return config;
  }
}