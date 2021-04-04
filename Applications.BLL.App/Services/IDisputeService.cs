using System.Threading.Tasks;
using Applications.BLL.Base.Services;
using Applications.DAL.App.Repositories;
using BLLAppDTO = BLL.App.DTO;
using DALAppDTO = DAL.App.DTO;

namespace Applications.BLL.App.Services
{
    public interface IDisputeService : IBaseEntityService<BLLAppDTO.Dispute, DALAppDTO.Dispute>, IDisputeRepositoryCustom<BLLAppDTO.Dispute>
    {
    }
}