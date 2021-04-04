using Applications.DAL.Base.Mappers;
using AutoMapper;

namespace BLL.App.Mappers
{
    public class ErApplicationMapper: BaseMapper<BLL.App.DTO.ErApplication, DAL.App.DTO.ErApplication>, 
        IBaseMapper<BLL.App.DTO.ErApplication, DAL.App.DTO.ErApplication>

    {
        public ErApplicationMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}