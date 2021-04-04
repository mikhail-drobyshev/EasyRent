using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Applications.BLL.Base.Mappers;
using Applications.BLL.Base.Services;
using Applications.DAL.Base;
using Applications.DAL.Base.Repositories;
using Applications.Domain.Base;

namespace BLL.Base.Services
{
    
    public class BaseEntityService<TUnitOfWork, TRepository, TBllEntity, TDalEntity>
        : BaseEntityService<TUnitOfWork, TRepository, TBllEntity, TDalEntity, Guid>, IBaseEntityService<TBllEntity, TDalEntity>
        where TBllEntity : class, IDomainEntityId
        where TDalEntity : class, IDomainEntityId
        where TUnitOfWork : IBaseUnitOfWork
        where TRepository : IBaseRepository<TDalEntity>
    {
        public BaseEntityService(TUnitOfWork serviceUow, TRepository serviceRepository, IBaseMapper<TBllEntity, TDalEntity> mapper) : base(serviceUow, serviceRepository, mapper)
        {
        }
    }

    
    public class BaseEntityService<TUnitOfWork,TRepository,TBllEntity, TDalEntity, TKey> : IBaseEntityService<TBllEntity, TDalEntity, TKey>
        where TBllEntity : class, IDomainEntityId<TKey> 
        where TDalEntity : class, IDomainEntityId<TKey> 
        where TKey : IEquatable<TKey>
        where TUnitOfWork: IBaseUnitOfWork
        where TRepository : IBaseRepository<TDalEntity, TKey>
    {
        protected TUnitOfWork ServiceUow;
        protected TRepository ServiceRepository;
        protected IBaseMapper<TBllEntity, TDalEntity> Mapper;
        
        public BaseEntityService(TUnitOfWork serviceUow, TRepository serviceRepository, IBaseMapper<TBllEntity, TDalEntity> mapper)
        {
            ServiceUow = serviceUow;
            ServiceRepository = serviceRepository;
            Mapper = mapper;
        }

        public TBllEntity Add(TBllEntity entity)
        {
            return Mapper.Map(ServiceRepository.Add(Mapper.Map(entity)!))!;
        }

        public TBllEntity Update(TBllEntity entity)
        {
            return Mapper.Map(ServiceRepository.Update(Mapper.Map(entity)!))!;
        }

        public TBllEntity Remove(TBllEntity entity, TKey? userId = default)
        {
            return Mapper.Map(ServiceRepository.Remove(Mapper.Map(entity)!, userId))!;
        }

        public async Task<IEnumerable<TBllEntity>> GetAllAsync(TKey? userId = default, bool noTracking = true)
        {
            return (await ServiceRepository.GetAllAsync(userId, noTracking)).Select(e=>Mapper.Map(e))!;
        }

        public async Task<TBllEntity?> FirstOrDefaultAsync(TKey id, TKey? userId = default, bool noTracking = true)
        {
            return Mapper.Map(await ServiceRepository.FirstOrDefaultAsync(id, userId, noTracking));
        }

        public async Task<bool> ExistsAsync(TKey id, TKey? userId = default)
        {
            return await ServiceRepository.ExistsAsync(id, userId);
        }

        public async Task<TBllEntity> RemoveAsync(TKey id, TKey? userId = default)
        {
            return Mapper.Map(await ServiceRepository.RemoveAsync(id, userId))!;
        }
    }
}