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
    public class GenderService: BaseEntityService<IAppUnitOfWork, IGenderRepository, BLLAppDTO.Gender, DALAppDTO.Gender>, IGenderService
    {
        public GenderService(IAppUnitOfWork serviceUow, IGenderRepository serviceRepository, IMapper mapper)
            : base(serviceUow, serviceRepository, new GenderMapper(mapper))
        {
        }
    }
}