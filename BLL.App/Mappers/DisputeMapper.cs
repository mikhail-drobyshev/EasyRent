using Applications.DAL.Base.Mappers;
using AutoMapper;

namespace BLL.App.Mappers
{
    public class DisputeMapper : BaseMapper<BLL.App.DTO.Dispute, DAL.App.DTO.Dispute>, IBaseMapper<BLL.App.DTO.Dispute, DAL.App.DTO.Dispute>

    {
        public DisputeMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}