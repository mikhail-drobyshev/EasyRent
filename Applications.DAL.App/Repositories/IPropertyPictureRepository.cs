using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Applications.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Applications.DAL.App.Repositories
{
    public interface IPropertyPictureRepository : IBaseRepository<PropertyPicture>, IPropertyPictureRepositoryCustom<PropertyPicture>
    {
        
    }
    
    public interface IPropertyPictureRepositoryCustom<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllWithPropertyIdAsync(Guid userId = default, bool noTracking = true);
        Task<IEnumerable<TEntity>> GetAllWithMediaAsync(Guid id);

    }
}