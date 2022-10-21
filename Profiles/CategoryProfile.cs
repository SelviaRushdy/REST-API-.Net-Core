using AutoMapper;

namespace REST_API_.Net_Core.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Entities.Category, Models.CategoriesDto>()
                .ForMember(
                    dest => dest.CatName,
                    opt => opt.MapFrom(src => src.Name)).ReverseMap();
        }
    }
}