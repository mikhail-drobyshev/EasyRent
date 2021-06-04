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
    public class PropertyService: BaseEntityService<IAppUnitOfWork, IPropertyRepository, BLLAppDTO.Property, DALAppDTO.Property>, IPropertyService
    {
        public PropertyService(IAppUnitOfWork serviceUow, IPropertyRepository serviceRepository, IMapper mapper)
            : base(serviceUow, serviceRepository, new PropertyMapper(mapper))
        {
        }

        public async Task<IEnumerable<BLLAppDTO.Property>> GetAllWithUserIdAsync(Guid userId,
            bool noTracking)
        {
            return (await ServiceRepository.GetAllWithUserIdAsync(userId, noTracking)).Select(x=>Mapper.Map(x))!;
        }
        
        public async Task<IEnumerable<BLLAppDTO.Property>> GetAllWithUserIdAsync(Guid userId = default)
        {
            return (await ServiceRepository.GetAllWithUserIdAsync(userId)).Select(x=>Mapper.Map(x))!;
        }
        
    }
}