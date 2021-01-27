using AutoMapper;
using Models.REST_API;
using Microsoft.Extensions.Options;
using Common.REST_API;
using Entity = Entities.REST_API;
namespace REST_API.Mapper
{


    //public class MemberValueResolver : IMemberValueResolver<object, object, decimal, decimal>
    //{
    //    private readonly IOptions<AppSettings> _settings;
    //    private readonly decimal priceMarkup;
    //    public MemberValueResolver(IOptions<AppSettings> settings)
    //    {
    //        _settings = settings;
    //        priceMarkup = _settings.Value.PriceMarkup;
    //    }
    //    public decimal Resolve(object source, object destination, decimal sourceMember, decimal destinationMember, ResolutionContext context)
    //    {
    //        return (sourceMember) + ((priceMarkup / 100m) * sourceMember);
    //    }
    //}


    //public class ValueResolver : IValueResolver<Entities.Product, Product, decimal>
    //{
    //    private readonly IOptions<AppSettings> _settings;
    //    private readonly decimal priceMarkup;
    //    public ValueResolver(IOptions<AppSettings> settings)
    //    {
    //        _settings = settings;
    //        priceMarkup = _settings.Value.PriceMarkup;
    //    }
    //    public decimal Resolve(Entities.Product source, Product destination, decimal sourceMember, ResolutionContext context)
    //    {
    //        return (source.UnitPrice) + ((priceMarkup / 100m) * source.UnitPrice);
    //    }
    //}

    public class ProductMapper : AutoMapper.Profile
    {
        public ProductMapper()
        {
            //CreateMap<ProductDTO, Product>()
            //    .ForMember(dest => dest.PriceWithMarkup, opt => opt.MapFrom<MemberValueResolver, decimal>(src => src.UnitPrice));

            #region Map from entity to model
            CreateMap<Entity.Product, Product>();

            CreateMap<Entity.ProductDesktop, ProductDesktop>()
                .ForMember(m => m.ProductId, e => e.MapFrom(et => et.Product.ProductId))
                .ForMember(m => m.ComputerTypeId, e => e.MapFrom(et => et.Product.ComputerTypeId))
                .ForMember(m => m.ComputerType, e => e.MapFrom(et => Enumeration.FromValue<ProductType>(et.Product.ComputerTypeId).Name))

                .ForMember(m => m.ProcessorId, e => e.MapFrom(et => et.Product.ProcessorId))
                .ForMember(m => m.Processor, e => e.MapFrom(et => Enumeration.FromValue<ProcessorType>(et.Product.ProcessorId).Name))

                .ForMember(m => m.BrandId, e => e.MapFrom(et => et.Product.BrandId))
                .ForMember(m => m.Brand, e => e.MapFrom(et => Enumeration.FromValue<Brand>(et.Product.BrandId).Name))

                .ForMember(m => m.FormFactor, e => e.MapFrom(et => Enumeration.FromValue<FormFactor>(et.FormFactorId).Name))

                .ForMember(m => m.USBPorts, e => e.MapFrom(et => et.Product.USBPorts))
                .ForMember(m => m.RamSlots, e => e.MapFrom(et => et.Product.RamSlots))
                .ForMember(m => m.Description, e => e.MapFrom(et => et.Product.Description))
                .ForMember(m => m.Quantity, e => e.MapFrom(et => et.Product.Quantity));

            CreateMap<Entity.ProductLaptop, ProductLaptop>()
               .ForMember(m => m.ProductId, e => e.MapFrom(et => et.Product.ProductId))
               .ForMember(m => m.ComputerTypeId, e => e.MapFrom(et => et.Product.ComputerTypeId))
               .ForMember(m => m.ComputerType, e => e.MapFrom(et => Enumeration.FromValue<ProductType>(et.Product.ComputerTypeId).Name))

               .ForMember(m => m.ProcessorId, e => e.MapFrom(et => et.Product.ProcessorId))
               .ForMember(m => m.Processor, e => e.MapFrom(et => Enumeration.FromValue<ProcessorType>(et.Product.ProcessorId).Name))

               .ForMember(m => m.BrandId, e => e.MapFrom(et => et.Product.BrandId))
               .ForMember(m => m.Brand, e => e.MapFrom(et => Enumeration.FromValue<Brand>(et.Product.BrandId).Name))

               .ForMember(m => m.USBPorts, e => e.MapFrom(et => et.Product.USBPorts))
               .ForMember(m => m.RamSlots, e => e.MapFrom(et => et.Product.RamSlots))
               .ForMember(m => m.Description, e => e.MapFrom(et => et.Product.Description))
               .ForMember(m => m.Quantity, e => e.MapFrom(et => et.Product.Quantity));

            #endregion

            #region Map from Model to Entity
            CreateMap<Product, Entity.Product>();

            CreateMap<ProductDesktop, Entity.ProductDesktop>()
                .ForMember(e => e.Product, m => m.MapFrom(et => new Product()
                {
                    ProductId = et.ProductId,
                    ComputerTypeId = et.ComputerTypeId,
                    ProcessorId = et.ProcessorId,
                    BrandId = et.BrandId,
                    USBPorts = et.USBPorts,
                    RamSlots = et.RamSlots,
                    Quantity = et.Quantity,
                    Description = et.Description
                }));
            //.ForMember(d => d.Children,
            //    opt => opt.MapFrom(src => new List<Child>() { new Child() { ChildId = src.ChildId, ChildName = src.ChildName } }));

            CreateMap<ProductLaptop, Entity.ProductLaptop>()
                  .ForMember(e => e.Product, m => m.MapFrom(et => new Product()
                  {
                      ProductId = et.ProductId,
                      ComputerTypeId = et.ComputerTypeId,
                      ProcessorId = et.ProcessorId,
                      BrandId = et.BrandId,
                      USBPorts = et.USBPorts,
                      RamSlots = et.RamSlots,
                      Quantity = et.Quantity,
                      Description = et.Description
                  }));

            #endregion
            //CreateMap<Entity.Product, Product>()
            //    .ForMember(dest => dest.ProductPrice,
            //    opt => opt.MapFrom<ValueResolver>());


        }

    }

}
