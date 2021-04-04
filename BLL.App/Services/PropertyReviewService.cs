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
    public class PropertyReviewService: BaseEntityService<IAppUnitOfWork, IPropertyReviewRepository, BLLAppDTO.PropertyReview, DALAppDTO.PropertyReview>, IPropertyReviewService
    {
        public PropertyReviewService(IAppUnitOfWork serviceUow, IPropertyReviewRepository serviceRepository, IMapper mapper)
            : base(serviceUow, serviceRepository, new PropertyReviewMapper(mapper))
        {
        }
    }
}