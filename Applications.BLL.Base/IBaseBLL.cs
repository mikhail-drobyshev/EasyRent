using System;
using System.Threading.Tasks;

namespace Applications.BLL.Base
{
    public interface IBaseBLL
    {
        Task<int> SaveChangesAsync();
        
        TService GetService<TService>(Func<TService> serviceCreationMethod)
            where TService : class;
    }
}