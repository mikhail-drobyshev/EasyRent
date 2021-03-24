using Applications.DAL.App.Repositories;
using Applications.DAL.Base.Repositories;
using DAL.Base.EF.Repositories;
using Domain.App;

namespace DAL.App.EF.Repositories
{
    public class PropertyTypeRepository: BaseRepository<PropertyType, AppDbContext>, IPropertyTypeRepository
    {
        public PropertyTypeRepository (AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}