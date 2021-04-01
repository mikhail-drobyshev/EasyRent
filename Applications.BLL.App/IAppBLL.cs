using System;
using Applications.BLL.App.Services;
using Applications.BLL.Base;
using Applications.DAL.App.Repositories;

namespace Applications.BLL.App
{
    public interface IAppBLL : IBaseBLL
    {
        IDisputeService Disputes { get; }
        
        // IDisputeStatusService DisputeStatuses { get; }
        // IErApplicationService ErApplications { get; }
        
        IDisputeStatusService DisputeStatuses { get; }
        IErApplicationService ErApplications { get; }

        IErApplicationStatusService ErApplicationStatuses { get; }
        IErUserService ErUsers { get; }
        IErUserReviewService ErUserReviews { get; }
        IErUserPictureService ErUserPictures { get; }
        IPropertyLocationService PropertyLocations { get; }
        IPropertyPictureService PropertyPictures { get; }
        IPropertyService Properties { get; }
        IPropertyReviewService PropertyReviews { get; }
        IPropertyTypeService PropertyTypes { get; }
        IGenderService Genders { get; }
    }
    
}