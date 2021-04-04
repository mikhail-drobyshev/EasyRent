using Applications.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Applications.DAL.App.Repositories
{
    public interface IPropertyRepository: IBaseRepository<Property>, IPropertyRepositoryCustom<Property>
    {
        
    }
    
    public interface IPropertyRepositoryCustom<TEntity>
    {
        
    }
}