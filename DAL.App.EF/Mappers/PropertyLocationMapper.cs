using Applications.DAL.Base.Mappers;
using AutoMapper;

namespace DAL.App.EF.Mappers
{
    public class PropertyLocationMapper: BaseMapper<DAL.App.DTO.PropertyLocation, Domain.App.PropertyLocation>, IBaseMapper<DAL.App.DTO.PropertyLocation, Domain.App.PropertyLocation>

    {

        public PropertyLocationMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}