using Applications.DAL.Base.Mappers;
using AutoMapper;

namespace BLL.App.Mappers
{
    public class ErUserPictureMapper: BaseMapper<BLL.App.DTO.ErUserPicture, DAL.App.DTO.ErUserPicture>, 
        IBaseMapper<BLL.App.DTO.ErUserPicture, DAL.App.DTO.ErUserPicture>

    {

        public ErUserPictureMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}