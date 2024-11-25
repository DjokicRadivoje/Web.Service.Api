using AutoMapper;
//using Web.Service.DataModel.Product;
using Web.Service.BusinessModel.Product;
namespace Web.Service.Mapper
{
    public class DefaultProfile: Profile
    {
        public DefaultProfile()
        {
            CreateMap<ProductRequest, DataModel.Product.ProductRequest>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<DataModel.Product.ProductResponse, ProductResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name));
        }
    }
}
