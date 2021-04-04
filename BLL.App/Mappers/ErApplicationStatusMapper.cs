using Applications.DAL.Base.Mappers;
using AutoMapper;

namespace BLL.App.Mappers
{
    public class ErApplicationStatusMapper: BaseMapper<BLL.App.DTO.ErApplicationStatus, DAL.App.DTO.ErApplicationStatus>, 
    IBaseMapper<BLL.App.DTO.ErApplicationStatus, DAL.App.DTO.ErApplicationStatus>

    {

        public ErApplicationStatusMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}