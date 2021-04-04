using Applications.DAL.Base.Mappers;
using AutoMapper;

namespace BLL.App.Mappers
{
    public class PropertyReviewMapper: BaseMapper<BLL.App.DTO.PropertyReview, DAL.App.DTO.PropertyReview>, 
        IBaseMapper<BLL.App.DTO.PropertyReview, DAL.App.DTO.PropertyReview>
    {
        public PropertyReviewMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}