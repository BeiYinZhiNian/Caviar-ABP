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

namespace Caviar
{
    public interface ICaviarRepository : IRepository, ITransientDependency
    {
        public IRepository<T> Set<T>() where T : class, IEntity<int>;
        public IRepository<T, TPrimaryKey> Set<T, TPrimaryKey>() where T : class, IEntity<TPrimaryKey>;
    }
}
