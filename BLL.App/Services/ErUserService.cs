using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Applications.BLL.App.Services;
using Applications.DAL.App;
using Applications.DAL.App.Repositories;
using AutoMapper;
using BLL.App.Mappers;
using BLL.Base.Services;
using BLLAppDTO = BLL.App.DTO;
using DALAppDTO = DAL.App.DTO;
using DTO.App;

namespace BLL.App.Services
{
    public class ErUserService : BaseEntityService<IAppUnitOfWork, IErUserRepository, BLLAppDTO.ErUser, DALAppDTO.ErUser>, IErUserService
    {
        public ErUserService(IAppUnitOfWork serviceUow, IErUserRepository serviceRepository, IMapper mapper)
            : base(serviceUow, serviceRepository, new ErUserMapper(mapper))
        {
        }

        public async Task<IEnumerable<BLLAppDTO.ErUser>> GetAllWithPropertyTypeCountAsync(Guid userId)
        {
            return (await ServiceRepository.GetAllWithPropertyTypeCountAsync(userId)).Select(x=>Mapper.Map(x))!;
        }

        public async Task<IEnumerable<BLLAppDTO.ErUser>> GetAllWithPropertyTypeCountAsync(Guid userId, bool noTracking)
        {
            return (await ServiceRepository.GetAllWithPropertyTypeCountAsync(userId, noTracking)).Select(x=>Mapper.Map(x))!;
        }

        public Task<IEnumerable<BLLAppDTO.ErUser>> GetAllErUsersWithInfo(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}