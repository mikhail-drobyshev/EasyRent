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
            Disputes = new DisputeRepository(uowDbContext);
            DisputeStatuses = new BaseRepository<DisputeStatus, AppDbContext>(uowDbContext);
            ErApplications = new ErApplicationRepository(uowDbContext);
            ErApplicationsStatuses = new BaseRepository<ErApplicationStatus, AppDbContext>(uowDbContext);
            ErUsers = new ErUserRepository(uowDbContext);
            ErUserReviews = new ErUserReviewRepository(uowDbContext);
            PropertyLocations = new PropertyLocationRepository(uowDbContext);
            PropertyPictures = new PropertyPictureRepository(uowDbContext);
            Properties = new PropertyRepository(uowDbContext);
            PropertyReviews = new PropertyReviewRepository(uowDbContext);
            PropertyTypes = new BaseRepository<PropertyType, AppDbContext>(uowDbContext);
        }

        public IDisputeRepository Disputes { get; }
        public IBaseRepository<DisputeStatus> DisputeStatuses { get; }
        public IErApplicationRepository ErApplications { get; }
        public IBaseRepository<ErApplicationStatus> ErApplicationsStatuses { get; }
        public IErUserRepository ErUsers { get; }
        public IErUserReviewRepository ErUserReviews { get; }
        public IPropertyLocationRepository PropertyLocations { get; }
        public IPropertyPictureRepository PropertyPictures { get; }
        public IPropertyRepository Properties { get; }
        public IPropertyReviewRepository PropertyReviews { get; }
        
        public IBaseRepository<PropertyType> PropertyTypes { get; }
    }
}