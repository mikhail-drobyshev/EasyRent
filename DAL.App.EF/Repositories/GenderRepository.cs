using Applications.DAL.App.Repositories;
using Applications.DAL.Base.Repositories;
using AutoMapper;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Domain.App;

namespace DAL.App.EF.Repositories
{
    public class GenderRepository: BaseRepository<DAL.App.DTO.Gender, Domain.App.Gender, AppDbContext>, IGenderRepository
    {
        public GenderRepository(AppDbContext dbContext, IMapper mapper
        ) : base(dbContext, new GenderMapper(mapper))
        {
        }
    }
}