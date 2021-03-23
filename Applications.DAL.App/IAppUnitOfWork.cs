using Applications.DAL.App.Repositories;
using Applications.DAL.Base;
using Applications.DAL.Base.Repositories;
using Domain.App;

namespace Applications.DAL.App
{
    public interface IAppUnitOfWork : IBaseUnitOfWork
    {
        IDisputeRepository Disputes { get; }
        
        // IDisputeStatusRepository DisputeStatuses { get; }
        // IErApplicationRepository ErApplications { get; }
        
        IBaseRepository<DisputeStatus> DisputeStatuses { get; }
        IErApplicationRepository ErApplications { get; }

        IBaseRepository<ErApplicationStatus> ErApplicationStatuses { get; }
        IErUserRepository ErUsers { get; }
        IErUserReviewRepository ErUserReviews { get; }
        IPropertyLocationRepository PropertyLocations { get; }
        IPropertyPictureRepository PropertyPictures { get; }
        IPropertyRepository Properties { get; }
        IPropertyReviewRepository PropertyReviews { get; }
        IBaseRepository<PropertyType> PropertyTypes { get; }
        IBaseRepository<Gender> Genders { get; }
        IBaseRepository<ErUserPicture> ErUserPictures { get; }

        
    }
}