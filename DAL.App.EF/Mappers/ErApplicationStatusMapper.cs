using Applications.DAL.Base.Mappers;
using AutoMapper;

namespace DAL.App.EF.Mappers
{
    public class ErApplicationStatusMapper: BaseMapper<DAL.App.DTO.ErApplicationStatus, Domain.App.ErApplicationStatus>,IBaseMapper<DAL.App.DTO.ErApplicationStatus, Domain.App.ErApplicationStatus>

    {

        public ErApplicationStatusMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}