using AutoMapper;
using ComputerEcommerce.Model;
using ComputerEcommerce.Shared.DTOs;

namespace ComputerEcommerce.Util
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();

            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<SaleDetail, SaleDetailDTO>().ReverseMap();
            CreateMap<Sale, SaleDTO>().ForMember(dest => dest.SaleDetailsDTO, opt => opt.MapFrom(src => src.SaleDetails)).ReverseMap();
            CreateMap<User, SessionDTO>().ReverseMap();
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email)).ReverseMap();
            CreateMap<User, RegisterDTO>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
           .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
           .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
           .ReverseMap();
        }
    }
}
