using Applications.DAL.Base.Mappers;
using AutoMapper;

namespace BLL.App.Mappers
{
    public class ErUserMapper: BaseMapper<BLL.App.DTO.ErUser, DAL.App.DTO.ErUser>, 
        IBaseMapper<BLL.App.DTO.ErUser, DAL.App.DTO.ErUser>

    {

        public ErUserMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}