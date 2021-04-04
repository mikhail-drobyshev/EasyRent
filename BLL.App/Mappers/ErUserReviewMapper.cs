using Applications.DAL.Base.Mappers;
using AutoMapper;

namespace BLL.App.Mappers
{
    public class ErUserReviewMapper: BaseMapper<BLL.App.DTO.ErUserReview, DAL.App.DTO.ErUserReview>, 
        IBaseMapper<BLL.App.DTO.ErUserReview, DAL.App.DTO.ErUserReview>

    {

        public ErUserReviewMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}