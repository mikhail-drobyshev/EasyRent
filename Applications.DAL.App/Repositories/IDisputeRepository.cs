using System.Threading.Tasks;
using Applications.DAL.Base.Repositories;
using DALAppDTO = DAL.App.DTO;

namespace Applications.DAL.App.Repositories
{
    public interface IDisputeRepository : IBaseRepository<DALAppDTO.Dispute>, IDisputeRepositoryCustom<DALAppDTO.Dispute>
    {
    }
    
    
    public interface IDisputeRepositoryCustom<in TEntity>
    {
        
    }
}