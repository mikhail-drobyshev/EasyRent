using Applications.DAL.Base.Mappers;
using AutoMapper;

namespace BLL.App.Mappers
{
    public class PropertyMapper: BaseMapper<BLL.App.DTO.Property, DAL.App.DTO.Property>, 
        IBaseMapper<BLL.App.DTO.Property, DAL.App.DTO.Property>

    {

        public PropertyMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}