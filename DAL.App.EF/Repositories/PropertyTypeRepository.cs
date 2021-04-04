using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Applications.DAL.App.Repositories;
using Applications.DAL.Base.Repositories;
using AutoMapper;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using Domain.App;
using DTO.App;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class PropertyTypeRepository: BaseRepository<DAL.App.DTO.PropertyType, Domain.App.PropertyType, AppDbContext>, IPropertyTypeRepository
    {
        public PropertyTypeRepository (AppDbContext dbContext, IMapper mapper) : base(dbContext, new PropertyTypeMapper(mapper))
        {
        }
        
        // public override async Task<IEnumerable<PropertyType>> GetAllAsync(Guid userId = default, bool noTracking = true)
        // {
        //     var query = CreateQuery(userId, noTracking);
        //
        //     query = query
        //         .Include(p => p.Properties);
        //     var res = await query.ToListAsync();
        //     return res;
        // }

        public async Task<IEnumerable<DAL.App.DTO.PropertyType>> GetAllWithPropertyTypeCountAsync(bool noTracking = true)
        {
            var query = CreateQuery(default, noTracking);
            var resultQuery = query.Select(propertyType => new DAL.App.DTO.PropertyType()
            {
                Id = propertyType.Id,
                PropertyTypeValue = propertyType.PropertyTypeValue,
                PropertyCount = propertyType.Properties!.Count
            });
            var result = await resultQuery.ToListAsync();
            return result;
        }
    }
}