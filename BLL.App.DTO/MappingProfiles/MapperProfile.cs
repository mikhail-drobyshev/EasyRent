using AutoMapper;
namespace BLL.App.DTO.MappingProfiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
            {
                CreateMap<Dispute, DAL.App.DTO.Property>().ReverseMap();
                CreateMap<DisputeStatus, DAL.App.DTO.DisputeStatus>().ReverseMap();
                CreateMap<ErApplication, DAL.App.DTO.ErApplication>().ReverseMap();
                CreateMap<ErApplicationStatus, DAL.App.DTO.ErApplicationStatus>().ReverseMap();
                CreateMap<ErUser, DAL.App.DTO.ErUser>().ReverseMap();
                CreateMap<ErUserPicture, DAL.App.DTO.ErUserPicture>().ReverseMap();
                CreateMap<ErUserReview, DAL.App.DTO.ErUserReview>().ReverseMap();
                CreateMap<Gender, DAL.App.DTO.Gender>().ReverseMap();
                CreateMap<Property, DAL.App.DTO.Property>().ReverseMap();
                CreateMap<PropertyLocation, DAL.App.DTO.PropertyLocation>().ReverseMap();
                CreateMap<PropertyPicture, DAL.App.DTO.PropertyPicture>().ReverseMap();
                CreateMap<PropertyReview, DAL.App.DTO.PropertyReview>().ReverseMap();
                CreateMap<PropertyType, DAL.App.DTO.PropertyType>().ReverseMap();
                
                CreateMap<Identity.AppRole, DAL.App.DTO.Identity.AppRole>().ReverseMap();
                CreateMap<Identity.AppUser, DAL.App.DTO.Identity.AppUser>().ReverseMap();
            }
        
    }
}