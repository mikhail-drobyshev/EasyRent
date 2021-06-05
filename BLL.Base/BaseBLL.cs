﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Applications.BLL.Base;
using Applications.DAL.Base;

namespace BLL.Base
{
    public class BaseBLL<TUnitOfWork> : IBaseBLL
    where TUnitOfWork: IBaseUnitOfWork
    {
        protected readonly TUnitOfWork Uow;
        
        public BaseBLL(TUnitOfWork uow)
        {
            this.Uow = uow;
        }
        
        public async Task<int> SaveChangesAsync()
        {
            return await Uow.SaveChangesAsync();
        }
        
        
        private readonly Dictionary<Type, object> _serviceCache = new();


        public TService GetService<TService>(Func<TService> serviceCreationMethod) where TService : class
        {
            if (_serviceCache.TryGetValue(typeof(TService), out var repo))
            {
                return (TService) repo;
            }

            var repoInstance = serviceCreationMethod();
            _serviceCache.Add(typeof(TService), repoInstance);
            return repoInstance;
        }
    }
}