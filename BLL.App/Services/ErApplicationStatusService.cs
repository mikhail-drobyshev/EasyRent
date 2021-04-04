using Applications.BLL.App.Services;
using Applications.DAL.App;
using Applications.DAL.App.Repositories;
using AutoMapper;
using BLL.App.Mappers;
using BLL.Base.Services;
using BLLAppDTO = BLL.App.DTO;
using DALAppDTO = DAL.App.DTO;

namespace BLL.App.Services
{
    public class ErApplicationStatusService : BaseEntityService<IAppUnitOfWork, IErApplicationStatusRepository, BLLAppDTO.ErApplicationStatus, DALAppDTO.ErApplicationStatus>, IErApplicationStatusService
    {
        public ErApplicationStatusService(IAppUnitOfWork serviceUow, IErApplicationStatusRepository serviceRepository, IMapper mapper)
            : base(serviceUow, serviceRepository, new ErApplicationStatusMapper(mapper))
        {
        }
    }
}