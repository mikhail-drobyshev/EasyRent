using System.Threading.Tasks;

namespace Applications.DAL.Base
{
    public interface IBaseUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}