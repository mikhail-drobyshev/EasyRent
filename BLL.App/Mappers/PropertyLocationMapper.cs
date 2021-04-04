using Applications.DAL.Base.Mappers;
using AutoMapper;

namespace BLL.App.Mappers
{
    public class PropertyLocationMapper: BaseMapper<BLL.App.DTO.PropertyLocation, DAL.App.DTO.PropertyLocation>, 
        IBaseMapper<BLL.App.DTO.PropertyLocation, DAL.App.DTO.PropertyLocation>

    {

        public PropertyLocationMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}