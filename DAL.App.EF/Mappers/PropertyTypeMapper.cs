using Applications.DAL.Base.Mappers;
using AutoMapper;

namespace DAL.App.EF.Mappers
{
    public class PropertyTypeMapper:BaseMapper<DAL.App.DTO.PropertyType, Domain.App.PropertyType>, IBaseMapper<DAL.App.DTO.PropertyType, Domain.App.PropertyType>

    {

        public PropertyTypeMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}