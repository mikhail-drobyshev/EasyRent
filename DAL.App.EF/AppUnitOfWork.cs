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
            ErApplications = new BaseRepository<ErApplication, AppDbContext>(uowDbContext);
        }

        public IDisputeRepository Disputes { get; }
        public IBaseRepository<DisputeStatus> DisputeStatuses { get; }
        public IBaseRepository<ErApplication> ErApplications { get; }
    }
}