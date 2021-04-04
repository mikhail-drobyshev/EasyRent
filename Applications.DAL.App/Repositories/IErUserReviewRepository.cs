using Applications.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Applications.DAL.App.Repositories
{
    public interface IErUserReviewRepository : IBaseRepository<ErUserReview>, IErUserReviewRepositoryCustom<ErUserReview>
    {
        
    }
    
    
    public interface IErUserReviewRepositoryCustom<TEntity>
    {
        
    }
}