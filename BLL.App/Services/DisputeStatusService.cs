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
    public class DisputeStatusService : BaseEntityService<IAppUnitOfWork, IDisputeStatusRepository, BLLAppDTO.DisputeStatus, DALAppDTO.DisputeStatus>, IDisputeStatusService
    {
        public DisputeStatusService(IAppUnitOfWork serviceUow, IDisputeStatusRepository serviceRepository, IMapper mapper)
            : base(serviceUow, serviceRepository, new DisputeStatusMapper(mapper))
        {
        }
    }
}