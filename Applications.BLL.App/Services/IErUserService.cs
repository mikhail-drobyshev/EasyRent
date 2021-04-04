using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Applications.BLL.Base.Services;
using Applications.DAL.App.Repositories;
using BLLAppDTO = BLL.App.DTO;
using DALAppDTO = DAL.App.DTO;
using DTO.App;

namespace Applications.BLL.App.Services
{
    public interface IErUserService : IBaseEntityService<BLLAppDTO.ErUser, DALAppDTO.ErUser>, IErUserRepositoryCustom<BLLAppDTO.ErUser>
    {
        Task<IEnumerable<BLLAppDTO.ErUser>> GetAllErUsersWithInfo(Guid userId);

    }
}