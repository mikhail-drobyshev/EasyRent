using Applications.DAL.Base.Mappers;
using AutoMapper;

namespace BLL.App.Mappers
{
    public class GenderMapper: BaseMapper<BLL.App.DTO.Gender, DAL.App.DTO.Gender>, 
        IBaseMapper<BLL.App.DTO.Gender, DAL.App.DTO.Gender>

    {

        public GenderMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}