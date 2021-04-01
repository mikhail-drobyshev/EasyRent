using Applications.BLL.App.Services;
using Applications.DAL.App;
using Applications.DAL.App.Repositories;
using BLL.Base.Services;
using Domain.App;

namespace BLL.App.Services
{
    public class PropertyReviewService: BaseEntityService<IAppUnitOfWork, IPropertyReviewRepository, PropertyReview>, IPropertyReviewService
    {
        public PropertyReviewService(IAppUnitOfWork serviceUow, IPropertyReviewRepository serviceRepository) : base(serviceUow, serviceRepository)
        {
        }
    }
}