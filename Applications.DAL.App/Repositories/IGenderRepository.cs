using Applications.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Applications.DAL.App.Repositories
{
    public interface IGenderRepository : IBaseRepository<Gender>, IGenderRepositoryCustom<Gender>
    {
        
    }
    
    public interface IGenderRepositoryCustom<TEntity>
    {
        
    }
}