using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Applications.BLL.App.Services;
using Applications.DAL.App;
using Applications.DAL.App.Repositories;
using BLL.Base.Services;
using Domain.App;
using DTO.App;

namespace BLL.App.Services
{
    public class ErUserService : BaseEntityService<IAppUnitOfWork, IErUserRepository, ErUser>, IErUserService
    {
        public ErUserService(IAppUnitOfWork serviceUow, IErUserRepository serviceRepository) : base(serviceUow, serviceRepository)
        {
        }

        public async Task<IEnumerable<ErUserDTO>> GetAllWithPropertyTypeCountAsync(Guid userId)
        {
            return await ServiceRepository.GetAllWithPropertyTypeCountAsync(userId);
        }

        public async Task<IEnumerable<ErUserDTO>> GetAllWithPropertyTypeCountAsync(Guid userId, bool noTracking)
        {
            return await ServiceRepository.GetAllWithPropertyTypeCountAsync(userId, noTracking);
        }

        public Task<IEnumerable<ErUserDTO>> GetAllErUsersWithInfo(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}