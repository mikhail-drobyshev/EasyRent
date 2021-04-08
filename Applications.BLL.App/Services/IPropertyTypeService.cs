using System.Collections.Generic;
using System.Threading.Tasks;
using Applications.BLL.Base.Services;
using Applications.DAL.App.Repositories;
using BLLAppDTO = BLL.App.DTO;
using DALAppDTO = DAL.App.DTO;

namespace Applications.BLL.App.Services
{
    public interface IPropertyTypeService: IBaseEntityService<BLLAppDTO.PropertyType, DALAppDTO.PropertyType>, IPropertyTypeRepositoryCustom<BLLAppDTO.PropertyType>
    {
        //Task<IEnumerable<BLLAppDTO.PropertyType>> GetAllWithPropertyTypeCountAsync(bool noTracking = true);

    }
}