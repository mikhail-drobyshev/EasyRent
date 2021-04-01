using Applications.BLL.Base.Services;
using Applications.DAL.Base.Repositories;
using Domain.App;

namespace Applications.DAL.App.Repositories
{
    public interface IErApplicationStatusService: IBaseEntityService<ErApplicationStatus>, IErApplicationStatusRepository
    {
        
    }
}