using Applications.DAL.Base.Mappers;
using AutoMapper;

namespace DAL.App.EF.Mappers
{
    public class PropertyPictureMapper: BaseMapper<DAL.App.DTO.PropertyPicture, Domain.App.PropertyPicture>, IBaseMapper<DAL.App.DTO.PropertyPicture, Domain.App.PropertyPicture>

    {

        public PropertyPictureMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}