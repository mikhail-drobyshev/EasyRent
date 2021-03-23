using System.Threading.Tasks;
using Applications.DAL.App;
using Applications.DAL.App.Repositories;
using Applications.DAL.Base.Repositories;
using DAL.App.EF.Repositories;
using DAL.Base;
using DAL.Base.EF;
using DAL.Base.EF.Repositories;
using Domain.App;

namespace DAL.App.EF
{
    public class AppUnitOfWork : BaseUnitOfWork<AppDbContext>, IAppUnitOfWork
    {
        public AppUnitOfWork(AppDbContext uowDbContext) : base(uowDbContext)
        {
                
        }

        public IDisputeRepository Disputes =>
                GetRepository(() => new DisputeRepository(UowDbContext));
        public IBaseRepository<DisputeStatus> DisputeStatuses =>
                GetRepository(() => new BaseRepository<DisputeStatus, AppDbContext>(UowDbContext));
        public IErApplicationRepository ErApplications =>
                GetRepository(() => new ErApplicationRepository(UowDbContext));
        public IBaseRepository<ErApplicationStatus> ErApplicationStatuses =>
                GetRepository(() => new BaseRepository<ErApplicationStatus, AppDbContext>(UowDbContext));
        public IErUserRepository ErUsers =>
                GetRepository(() => new ErUserRepository(UowDbContext));
        public IErUserReviewRepository ErUserReviews =>
                GetRepository(() => new ErUserReviewRepository(UowDbContext));
        public IPropertyLocationRepository PropertyLocations =>
                GetRepository(() => new PropertyLocationRepository(UowDbContext));
        public IPropertyPictureRepository PropertyPictures =>
                GetRepository(() => new PropertyPictureRepository(UowDbContext));
        public IPropertyRepository Properties =>
                GetRepository(() => new PropertyRepository(UowDbContext));
        public IPropertyReviewRepository PropertyReviews =>
                GetRepository(() => new PropertyReviewRepository(UowDbContext));
        public IBaseRepository<PropertyType> PropertyTypes =>
                GetRepository(() => new BaseRepository<PropertyType, AppDbContext>(UowDbContext));
        public IBaseRepository<Gender> Genders =>
                GetRepository(() => new BaseRepository<Gender, AppDbContext>(UowDbContext));
        public IBaseRepository<ErUserPicture> ErUserPictures =>
                GetRepository(() => new BaseRepository<ErUserPicture, AppDbContext>(UowDbContext));

    }
}