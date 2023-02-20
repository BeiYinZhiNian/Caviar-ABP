// Copyright (c) BeiYinZhiNian (1031622947@qq.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Dependency;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Caviar
{
    public class CaviarRepository : ICaviarRepository
    {
        private readonly IServiceProvider _serviceProvider;

        public CaviarRepository(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IRepository<T> Set<T>() where T : class, IEntity<int>
        {
            return _serviceProvider.GetService<IRepository<T>>();
        }

        public IRepository<T, TPrimaryKey> Set<T, TPrimaryKey>() where T : class, IEntity<TPrimaryKey>
        {
            return _serviceProvider.GetService<IRepository<T, TPrimaryKey>>();
        }
    }
}
