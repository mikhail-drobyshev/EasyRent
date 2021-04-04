using Applications.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Applications.DAL.App.Repositories
{
    public interface IPropertyPictureRepository : IBaseRepository<PropertyPicture>, IPropertyPictureRepositoryCustom<PropertyPicture>
    {
        
    }
    
    public interface IPropertyPictureRepositoryCustom<TEntity>
    {
        
    }
}