using System;
using Applications.BLL.App;
using Applications.BLL.App.Services;
using Applications.DAL.App;
using Applications.DAL.App.Repositories;
using AutoMapper;
using BLL.App.Services;
using BLL.Base;

namespace BLL.App
{
    public class AppBLL : BaseBLL<IAppUnitOfWork>, IAppBLL
    {
        protected IMapper Mapper;
        public AppBLL(IAppUnitOfWork uow, IMapper mapper) : base(uow)
        {
            Mapper = mapper;
        }

        public IDisputeService Disputes =>
            GetService<IDisputeService>(() => new DisputeService(Uow, Uow.Disputes, Mapper));
        public IDisputeStatusService DisputeStatuses =>
            GetService<IDisputeStatusService>(() => new DisputeStatusService(Uow, Uow.DisputeStatuses, Mapper));
        public IErApplicationService ErApplications =>
            GetService<IErApplicationService>(() => new ErApplicationService(Uow, Uow.ErApplications, Mapper));
        public IErApplicationStatusService ErApplicationStatuses =>
            GetService<IErApplicationStatusService>(() => new ErApplicationStatusService(Uow, Uow.ErApplicationStatuses, Mapper));
        public IErUserService ErUsers =>
            GetService<IErUserService>(() => new ErUserService(Uow, Uow.ErUsers, Mapper));
        public IErUserReviewService ErUserReviews =>
            GetService<IErUserReviewService>(() => new ErUserReviewService(Uow, Uow.ErUserReviews, Mapper));
        public IErUserPictureService ErUserPictures =>
            GetService<IErUserPictureService>(() => new ErUserPictureService(Uow, Uow.ErUserPictures, Mapper));
        public IPropertyLocationService PropertyLocations =>
            GetService<IPropertyLocationService>(() => new PropertyLocationService(Uow, Uow.PropertyLocations, Mapper));
        public IPropertyPictureService PropertyPictures =>
            GetService<IPropertyPictureService>(() => new PropertyPictureService(Uow, Uow.PropertyPictures, Mapper));
        public IPropertyService Properties =>
            GetService<IPropertyService>(() => new PropertyService(Uow, Uow.Properties, Mapper));
        public IPropertyReviewService PropertyReviews =>
            GetService<IPropertyReviewService>(() => new PropertyReviewService(Uow, Uow.PropertyReviews, Mapper));
        public IPropertyTypeService PropertyTypes =>
            GetService<IPropertyTypeService>(() => new PropertyTypeService(Uow, Uow.PropertyTypes, Mapper));
        public IGenderService Genders =>
            GetService<IGenderService>(() => new GenderService(Uow, Uow.Genders, Mapper));
    }
}