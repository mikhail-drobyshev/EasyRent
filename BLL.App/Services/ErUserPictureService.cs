using System;
using System.Collections.Generic;
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
    public class ErUserPictureService : BaseEntityService<IAppUnitOfWork, IErUserPictureRepository, BLLAppDTO.ErUserPicture, DALAppDTO.ErUserPicture>, IErUserPictureService
    {
        public ErUserPictureService(IAppUnitOfWork serviceUow, IErUserPictureRepository serviceRepository, IMapper mapper)
            : base(serviceUow, serviceRepository, new ErUserPictureMapper(mapper))
        {
        }
    }
}