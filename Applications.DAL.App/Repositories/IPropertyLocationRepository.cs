using Applications.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Applications.DAL.App.Repositories
{
    public interface IPropertyLocationRepository : IBaseRepository<PropertyLocation>, IPropertyLocationRepositoryCustom<PropertyLocation>
    {
        
    }
    
    public interface IPropertyLocationRepositoryCustom<TEntity>
    {
        
    }
}