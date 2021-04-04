using Applications.DAL.Base.Mappers;
using AutoMapper;

namespace DAL.App.EF.Mappers
{
    public class ErUserReviewMapper: BaseMapper<DAL.App.DTO.ErUserReview, Domain.App.ErUserReview>, IBaseMapper<DAL.App.DTO.ErUserReview, Domain.App.ErUserReview>

    {

        public ErUserReviewMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}