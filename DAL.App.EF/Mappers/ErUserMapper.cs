using Applications.DAL.Base.Mappers;
using AutoMapper;

namespace DAL.App.EF.Mappers
{
    public class ErUserMapper: BaseMapper<DAL.App.DTO.ErUser, Domain.App.ErUser>,IBaseMapper<DAL.App.DTO.ErUser, Domain.App.ErUser>

    {

        public ErUserMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}