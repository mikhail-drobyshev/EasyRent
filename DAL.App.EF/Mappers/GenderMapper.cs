using Applications.DAL.Base.Mappers;
using AutoMapper;

namespace DAL.App.EF.Mappers
{
    public class GenderMapper: BaseMapper<DAL.App.DTO.Gender, Domain.App.Gender>, IBaseMapper<DAL.App.DTO.Gender, Domain.App.Gender>

    {

        public GenderMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}