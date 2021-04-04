using Applications.BLL.Base.Services;
using Applications.DAL.App.Repositories;
using BLLAppDTO = BLL.App.DTO;
using DALAppDTO = DAL.App.DTO;

namespace Applications.BLL.App.Services
{
    public interface IErApplicationStatusService: IBaseEntityService<BLLAppDTO.ErApplicationStatus, DALAppDTO.ErApplicationStatus>, IErApplicationStatusRepositoryCustom<BLLAppDTO.ErApplicationStatus>
    {
        
    }
}