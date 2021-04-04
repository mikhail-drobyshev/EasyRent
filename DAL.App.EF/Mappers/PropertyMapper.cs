using Applications.DAL.Base.Mappers;
using AutoMapper;

namespace DAL.App.EF.Mappers
{
    public class PropertyMapper: BaseMapper<DAL.App.DTO.Property, Domain.App.Property>,IBaseMapper<DAL.App.DTO.Property, Domain.App.Property>

    {

        public PropertyMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}