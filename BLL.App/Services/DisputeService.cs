using System.Threading.Tasks;
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
    public class DisputeService : BaseEntityService<IAppUnitOfWork, IDisputeRepository, BLLAppDTO.Dispute, DALAppDTO.Dispute>, IDisputeService
    {
        public DisputeService(IAppUnitOfWork serviceUow, IDisputeRepository serviceRepository, IMapper mapper)
            : base(serviceUow, serviceRepository, new DisputeMapper(mapper))
        {
        }

        
    }
}