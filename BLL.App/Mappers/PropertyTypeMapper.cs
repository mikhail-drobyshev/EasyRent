using Applications.DAL.Base.Mappers;
using AutoMapper;

namespace BLL.App.Mappers
{
    public class PropertyTypeMapper:BaseMapper<BLL.App.DTO.PropertyType, DAL.App.DTO.PropertyType>, 
        IBaseMapper<BLL.App.DTO.PropertyType, DAL.App.DTO.PropertyType>

    {

        public PropertyTypeMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}