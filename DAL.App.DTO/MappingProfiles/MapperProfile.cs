using AutoMapper;
using DAL.App.DTO.Identity;

namespace DAL.App.DTO.MappingProfiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
            {
                CreateMap<Dispute, Domain.App.Property>().ReverseMap();
                CreateMap<DisputeStatus, Domain.App.DisputeStatus>().ReverseMap();
                CreateMap<ErApplication, Domain.App.ErApplication>().ReverseMap();
                CreateMap<ErApplicationStatus, Domain.App.ErApplicationStatus>().ReverseMap();
                CreateMap<ErUser, Domain.App.ErUser>().ReverseMap();
                CreateMap<ErUserPicture, Domain.App.ErUserPicture>().ReverseMap();
                CreateMap<ErUserReview, Domain.App.ErUserReview>().ReverseMap();
                CreateMap<Gender, Domain.App.Gender>().ReverseMap();
                CreateMap<Property, Domain.App.Property>().ReverseMap();
                CreateMap<PropertyLocation, Domain.App.PropertyLocation>().ReverseMap();
                CreateMap<PropertyPicture, Domain.App.PropertyPicture>().ReverseMap();
                CreateMap<PropertyReview, Domain.App.PropertyReview>().ReverseMap();
                CreateMap<PropertyType, Domain.App.PropertyType>().ReverseMap();
                
                CreateMap<AppRole, Domain.App.Identity.AppRole>().ReverseMap();
                CreateMap<AppUser, Domain.App.Identity.AppUser>().ReverseMap();
            }
        
    }
}