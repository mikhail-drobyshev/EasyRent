using Applications.DAL.Base.Mappers;
using AutoMapper;

namespace DAL.App.EF.Mappers
{
    public class ErApplicationMapper: BaseMapper<DAL.App.DTO.ErApplication, Domain.App.ErApplication>, IBaseMapper<DAL.App.DTO.ErApplication, Domain.App.ErApplication>

    {
        public ErApplicationMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}