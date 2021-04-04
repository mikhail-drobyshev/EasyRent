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
    public class ErUserReviewService: BaseEntityService<IAppUnitOfWork, IErUserReviewRepository, BLLAppDTO.ErUserReview, DALAppDTO.ErUserReview>, IErUserReviewService
    {
        public ErUserReviewService(IAppUnitOfWork serviceUow, IErUserReviewRepository serviceRepository, IMapper mapper)
            : base(serviceUow, serviceRepository, new ErUserReviewMapper(mapper))
        {
        }
    }
}