using Applications.DAL.Base.Mappers;
using AutoMapper;

namespace DAL.App.EF.Mappers
{
    public class PropertyReviewMapper: BaseMapper<DAL.App.DTO.PropertyReview, Domain.App.PropertyReview>, IBaseMapper<DAL.App.DTO.PropertyReview, Domain.App.PropertyReview>
    {
        public PropertyReviewMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}