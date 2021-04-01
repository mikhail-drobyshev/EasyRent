using Applications.BLL.Base.Services;
using Applications.DAL.App.Repositories;
using Domain.App;

namespace Applications.BLL.App.Services
{
    public interface IGenderService : IBaseEntityService<Gender>, IGenderRepository
    {
        
    }
}