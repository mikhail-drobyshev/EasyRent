using Applications.DAL.Base.Mappers;
using AutoMapper;

namespace DAL.App.EF.Mappers
{
    public class DisputeStatusMapper: BaseMapper<DAL.App.DTO.DisputeStatus, Domain.App.DisputeStatus>, IBaseMapper<DAL.App.DTO.DisputeStatus, Domain.App.DisputeStatus>
    {

        public DisputeStatusMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}