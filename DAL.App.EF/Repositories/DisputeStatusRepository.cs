using Applications.DAL.App.Repositories;
using Applications.DAL.Base.Repositories;
using AutoMapper;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Domain.App;

namespace DAL.App.EF.Repositories
{
    public class DisputeStatusRepository: BaseRepository<DAL.App.DTO.DisputeStatus, Domain.App.DisputeStatus, AppDbContext>, IDisputeStatusRepository
    {
        public DisputeStatusRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, new DisputeStatusMapper(mapper))
        {
        }
    }
}