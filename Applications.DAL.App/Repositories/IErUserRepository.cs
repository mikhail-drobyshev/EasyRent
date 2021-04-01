using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Applications.DAL.Base.Repositories;
using Domain.App;
using DTO.App;

namespace Applications.DAL.App.Repositories
{
    public interface IErUserRepository : IBaseRepository<ErUser>
    {
        Task<IEnumerable<ErUserDTO>> GetAllWithPropertyTypeCountAsync(Guid userId,bool noTracking = true);

    }
}