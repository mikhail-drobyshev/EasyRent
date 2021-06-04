using System;
using System.Collections.Generic;
using System.Linq;
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
    public class PropertyPictureService: BaseEntityService<IAppUnitOfWork, IPropertyPictureRepository, BLLAppDTO.PropertyPicture, DALAppDTO.PropertyPicture>, IPropertyPictureService
    {
        public PropertyPictureService(IAppUnitOfWork serviceUow, IPropertyPictureRepository serviceRepository, IMapper mapper)
            : base(serviceUow, serviceRepository, new PropertyPictureMapper(mapper))
        
        {
        }

        public async Task<IEnumerable<BLLAppDTO.PropertyPicture>> GetAllWithPropertyIdAsync(Guid userId = default, bool noTracking = true)
        {
            return (await ServiceRepository.GetAllWithPropertyIdAsync(userId, noTracking)).Select(x=>Mapper.Map(x))!;
        }
    }
}