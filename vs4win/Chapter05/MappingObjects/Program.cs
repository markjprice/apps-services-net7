using AutoMapper; // MapperConfiguration, IMapper
using Packt.Entities; // Customer, Cart, LineItem
using Packt.ViewModels; // Summary

// create an object model from "entity" model types that
// might have come from a data store

Cart cart = new(
  Customer: new(
    FirstName: "John",
    LastName: "Smith"
  ), 
  Items: new()
  {
    new(ProductName: "Apples", UnitPrice: 0.49M, Quantity: 10),
    new(ProductName: "Bananas", UnitPrice: 0.99M, Quantity: 4)
  }
);

WriteLine($"{cart.Customer}");
foreach (LineItem item in cart.Items)
{
  WriteLine($"  {item}");
}

// confugure mappings using projections

MapperConfiguration config = new(cfg =>
  {
    cfg.CreateMap<Cart, Summary>()
     .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => 
        string.Format("{0} {1}", src.Customer.FirstName, src.Customer.LastName)
      ))
     .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Items.Sum(item => item.UnitPrice * item.Quantity)));
  }
);

// create a mapper, perform the mapping, and output the result

IMapper mapper = config.CreateMapper();

Summary summary = mapper.Map<Cart, Summary>(cart);

WriteLine($"Summary: {summary.FullName} spent {summary.Total}.");
