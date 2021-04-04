using Applications.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Applications.DAL.App.Repositories
{
    public interface IPropertyReviewRepository: IBaseRepository<PropertyReview>, IPropertyReviewRepositoryCustom<PropertyReview>
    {
        
    }
    
    public interface IPropertyReviewRepositoryCustom<TEntity>
    {
        
    }
}