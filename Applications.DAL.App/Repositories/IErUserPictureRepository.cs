using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Applications.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Applications.DAL.App.Repositories
{
    public interface IErUserPictureRepository : IBaseRepository<ErUserPicture>, IErUserPictureRepositoryCustom<ErUserPicture>
    {

    }
    
    public interface IErUserPictureRepositoryCustom<TEntity>
    {
        
    }
}