using AutoMapper;

namespace REST_API_.Net_Core.Profiles
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Entities.Products, Models.ProductsDto>()
                .ForMember(
                    dest => dest.ProdName,
                    opt => opt.MapFrom(src => src.Name)).ReverseMap();

            CreateMap<Entities.Products, Models.ProductDtoForUpdate>()
               .ForMember(
                   dest => dest.ProdName,
                   opt => opt.MapFrom(src => src.Name)).ReverseMap();

        }
    }
}
