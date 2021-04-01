using System;
using Applications.BLL.App;
using Applications.BLL.App.Services;
using Applications.DAL.App;
using Applications.DAL.App.Repositories;
using BLL.App.Services;
using BLL.Base;

namespace BLL.App
{
    public class AppBLL : BaseBLL<IAppUnitOfWork>, IAppBLL
    {
        public AppBLL(IAppUnitOfWork uow) : base(uow)
        {
        }

        public IDisputeService Disputes =>
            GetService<IDisputeService>(() => new DisputeService(Uow, Uow.Disputes));
        public IDisputeStatusService DisputeStatuses =>
            GetService<IDisputeStatusService>(() => new DisputeStatusService(Uow, Uow.DisputeStatuses));
        public IErApplicationService ErApplications =>
            GetService<IErApplicationService>(() => new ErApplicationService(Uow, Uow.ErApplications));
        public IErApplicationStatusService ErApplicationStatuses =>
            GetService<IErApplicationStatusService>(() => new ErApplicationStatusService(Uow, Uow.ErApplicationStatuses));
        public IErUserService ErUsers =>
            GetService<IErUserService>(() => new ErUserService(Uow, Uow.ErUsers));
        public IErUserReviewService ErUserReviews =>
            GetService<IErUserReviewService>(() => new ErUserReviewService(Uow, Uow.ErUserReviews));
        public IErUserPictureService ErUserPictures =>
            GetService<IErUserPictureService>(() => new ErUserPictureService(Uow, Uow.ErUserPictures));
        public IPropertyLocationService PropertyLocations =>
            GetService<IPropertyLocationService>(() => new PropertyLocationService(Uow, Uow.PropertyLocations));
        public IPropertyPictureService PropertyPictures =>
            GetService<IPropertyPictureService>(() => new PropertyPictureService(Uow, Uow.PropertyPictures));
        public IPropertyService Properties =>
            GetService<IPropertyService>(() => new PropertyService(Uow, Uow.Properties));
        public IPropertyReviewService PropertyReviews =>
            GetService<IPropertyReviewService>(() => new PropertyReviewService(Uow, Uow.PropertyReviews));
        public IPropertyTypeService PropertyTypes =>
            GetService<IPropertyTypeService>(() => new PropertyTypeService(Uow, Uow.PropertyTypes));
        public IGenderService Genders =>
            GetService<IGenderService>(() => new GenderService(Uow, Uow.Genders));
    }
}