// Copyright (c) BeiYinZhiNian (1031622947@qq.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Caviar.EntityFrameworkCore
{
    public static class CaviarDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<CaviarDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<CaviarDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
