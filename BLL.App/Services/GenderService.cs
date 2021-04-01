using Applications.BLL.App.Services;
using Applications.DAL.App;
using Applications.DAL.App.Repositories;
using BLL.Base.Services;
using Domain.App;

namespace BLL.App.Services
{
    public class GenderService: BaseEntityService<IAppUnitOfWork, IGenderRepository, Gender>, IGenderService
    {
        public GenderService(IAppUnitOfWork serviceUow, IGenderRepository serviceRepository) : base(serviceUow, serviceRepository)
        {
        }
    }
}