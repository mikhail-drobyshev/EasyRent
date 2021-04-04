using Applications.DAL.Base.Mappers;
using AutoMapper;

namespace DAL.App.EF.Mappers
{
    public class ErUserPictureMapper: BaseMapper<DAL.App.DTO.ErUserPicture, Domain.App.ErUserPicture>, IBaseMapper<DAL.App.DTO.ErUserPicture, Domain.App.ErUserPicture>

    {

        public ErUserPictureMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}