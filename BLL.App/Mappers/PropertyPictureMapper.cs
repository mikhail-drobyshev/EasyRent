using Applications.DAL.Base.Mappers;
using AutoMapper;

namespace BLL.App.Mappers
{
    public class PropertyPictureMapper: BaseMapper<BLL.App.DTO.PropertyPicture, DAL.App.DTO.PropertyPicture>, 
        IBaseMapper<BLL.App.DTO.PropertyPicture, DAL.App.DTO.PropertyPicture>

    {

        public PropertyPictureMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}