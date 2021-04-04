using System.Threading.Tasks;
using Applications.DAL.App;
using Applications.DAL.App.Repositories;
using Applications.DAL.Base.Repositories;
using AutoMapper;
using DAL.App.EF.Repositories;
using DAL.Base;
using DAL.Base.EF;
using DAL.Base.EF.Repositories;
using Domain.App;


namespace DAL.App.EF
{
    public class AppUnitOfWork : BaseUnitOfWork<AppDbContext>, IAppUnitOfWork
    { 
        protected IMapper Mapper;
        public AppUnitOfWork(AppDbContext uowDbContext, IMapper mapper) : base(uowDbContext)
        { 
                Mapper = mapper;
        }

        public IDisputeRepository Disputes =>
                GetRepository(() => new DisputeRepository(UowDbContext,Mapper));
        public IDisputeStatusRepository DisputeStatuses =>
                GetRepository(() => new DisputeStatusRepository(UowDbContext,Mapper));
        public IErApplicationStatusRepository ErApplicationStatuses =>
                GetRepository(() => new ErApplicationStatusRepository(UowDbContext,Mapper));
        public IErApplicationRepository ErApplications =>
                GetRepository(() => new ErApplicationRepository(UowDbContext,Mapper));
        public IErUserRepository ErUsers =>
                GetRepository(() => new ErUserRepository(UowDbContext,Mapper));
        public IErUserReviewRepository ErUserReviews =>
                GetRepository(() => new ErUserReviewRepository(UowDbContext,Mapper));
        public IPropertyLocationRepository PropertyLocations =>
                GetRepository(() => new PropertyLocationRepository(UowDbContext,Mapper));
        public IPropertyPictureRepository PropertyPictures =>
                GetRepository(() => new PropertyPictureRepository(UowDbContext,Mapper));
        public IPropertyRepository Properties =>
                GetRepository(() => new PropertyRepository(UowDbContext,Mapper));
        public IPropertyReviewRepository PropertyReviews =>
                GetRepository(() => new PropertyReviewRepository(UowDbContext,Mapper));
        public IPropertyTypeRepository PropertyTypes =>
                GetRepository(() => new PropertyTypeRepository(UowDbContext,Mapper));
        public IGenderRepository Genders =>
                GetRepository(() => new GenderRepository(UowDbContext,Mapper));
        public IErUserPictureRepository ErUserPictures =>
                GetRepository(() => new ErUserPictureRepository(UowDbContext,Mapper));

    }
}