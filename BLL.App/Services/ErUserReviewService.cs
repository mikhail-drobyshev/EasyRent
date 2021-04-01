using Applications.BLL.App.Services;
using Applications.DAL.App;
using Applications.DAL.App.Repositories;
using BLL.Base.Services;
using Domain.App;

namespace BLL.App.Services
{
    public class ErUserReviewService: BaseEntityService<IAppUnitOfWork, IErUserReviewRepository, ErUserReview>, IErUserReviewService
    {
        public ErUserReviewService(IAppUnitOfWork serviceUow, IErUserReviewRepository serviceRepository) : base(serviceUow, serviceRepository)
        {
        }
    }
}