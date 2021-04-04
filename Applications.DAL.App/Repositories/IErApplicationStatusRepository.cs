using Applications.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Applications.DAL.App.Repositories
{
    public interface IErApplicationStatusRepository: 
        IBaseRepository<ErApplicationStatus>, IErApplicationStatusRepositoryCustom<ErApplicationStatus>
    {
        
    }
    
    public interface IErApplicationStatusRepositoryCustom<TEntity>
    {
        
    }
}