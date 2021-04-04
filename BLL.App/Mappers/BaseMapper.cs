using Applications.BLL.Base.Mappers;
using AutoMapper;

namespace BLL.App.Mappers
{
    public class BaseMapper<TLeftEntity, TRightEntity> : IBaseMapper<TLeftEntity, TRightEntity>
    {
        protected IMapper Mapper;
        
        public BaseMapper(IMapper mapper)
        {
            Mapper = mapper;
        }
        public TLeftEntity? Map(TRightEntity? inObject)
        {
            return Mapper.Map<TLeftEntity>(inObject);
        }

        public TRightEntity? Map(TLeftEntity? inObject)
        {
            return Mapper.Map<TRightEntity>(inObject);
        }
    }
}