using Applications.DAL.App.Repositories;
using Applications.DAL.Base.Repositories;
using AutoMapper;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Domain.App;

namespace DAL.App.EF.Repositories
{
    public class ErApplicationStatusRepository: BaseRepository<DAL.App.DTO.ErApplicationStatus, Domain.App.ErApplicationStatus, AppDbContext>, IErApplicationStatusRepository
    {
        public ErApplicationStatusRepository(AppDbContext dbContext, IMapper mapper
        ) : base(dbContext, new ErApplicationStatusMapper(mapper))
        {
        }
    }
}