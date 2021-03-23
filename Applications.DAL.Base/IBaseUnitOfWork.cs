using System;
using System.Threading.Tasks;

namespace Applications.DAL.Base
{
    public interface IBaseUnitOfWork
    {
        Task<int> SaveChangesAsync();
        TRepository GetRepository<TRepository>(Func<TRepository> repoCreationMethod)
            where TRepository : class;

    }
}