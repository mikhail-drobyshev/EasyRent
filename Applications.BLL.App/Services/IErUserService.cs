using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Applications.BLL.Base.Services;
using Applications.DAL.App.Repositories;
using Domain.App;
using DTO.App;

namespace Applications.BLL.App.Services
{
    public interface IErUserService : IBaseEntityService<ErUser>, IErUserRepository
    {
        Task<IEnumerable<ErUserDTO>> GetAllWithPropertyTypeCountAsync(Guid userId);

    }
}