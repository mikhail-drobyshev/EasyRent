using Applications.DAL.Base.Mappers;
using AutoMapper;

namespace BLL.App.Mappers
{
    public class DisputeStatusMapper: BaseMapper<BLL.App.DTO.DisputeStatus, DAL.App.DTO.DisputeStatus>, 
        IBaseMapper<BLL.App.DTO.DisputeStatus, DAL.App.DTO.DisputeStatus>
    {

        public DisputeStatusMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}