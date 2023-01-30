// Copyright (c) BeiYinZhiNian (1031622947@qq.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Abp.Zero.EntityFrameworkCore;
using Caviar.Authorization.Roles;
using Caviar.Authorization.Users;
using Caviar.MultiTenancy;
using Microsoft.EntityFrameworkCore;

namespace Caviar.EntityFrameworkCore
{
    public class CaviarDbContext : AbpZeroDbContext<Tenant, Role, User, CaviarDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public CaviarDbContext(DbContextOptions<CaviarDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().Property(a => a.PhoneNumber).IsRequired(true);
            modelBuilder.Entity<User>().Property(a => a.EmailAddress).IsRequired(false);
            modelBuilder.Entity<User>().Property(a => a.NormalizedEmailAddress).IsRequired(false);
        }
    }
}
