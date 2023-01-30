// Copyright (c) BeiYinZhiNian (1031622947@qq.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Caviar.Configuration;
using Caviar.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Caviar.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class CaviarDbContextFactory : IDesignTimeDbContextFactory<CaviarDbContext>
    {
        public CaviarDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<CaviarDbContext>();

            /*
             You can provide an environmentName parameter to the AppConfigurations.Get method. 
             In this case, AppConfigurations will try to read appsettings.{environmentName}.json.
             Use Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") method or from string[] args to get environment if necessary.
             https://docs.microsoft.com/en-us/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli#args
             */
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            CaviarDbContextConfigurer.Configure(builder, configuration.GetConnectionString(CaviarConsts.ConnectionStringName));

            return new CaviarDbContext(builder.Options);
        }
    }
}
