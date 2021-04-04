using Applications.DAL.Base.Mappers;
using AutoMapper;

namespace DAL.App.EF.Mappers
{
    public class DisputeMapper : BaseMapper<DAL.App.DTO.Dispute, Domain.App.Dispute>, IBaseMapper<DAL.App.DTO.Dispute, Domain.App.Dispute>

    {
        public DisputeMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}