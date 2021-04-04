using Applications.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Applications.DAL.App.Repositories
{
    public interface IErApplicationRepository : IBaseRepository<ErApplication>, IErApplicationRepositoryCustom<ErApplication>
    {
        
    }
    
    public interface IErApplicationRepositoryCustom<TEntity>
    {
        
    }
}