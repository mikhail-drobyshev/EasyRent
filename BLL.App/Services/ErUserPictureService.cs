using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Applications.BLL.App.Services;
using Applications.DAL.App;
using Applications.DAL.App.Repositories;
using BLL.Base.Services;
using Domain.App;
using DTO.App;

namespace BLL.App.Services
{
    public class ErUserPictureService : BaseEntityService<IAppUnitOfWork, IErUserPictureRepository, ErUserPicture>, IErUserPictureService
    {
        public ErUserPictureService(IAppUnitOfWork serviceUow, IErUserPictureRepository serviceRepository) : base(serviceUow, serviceRepository)
        {
        }
    }
}