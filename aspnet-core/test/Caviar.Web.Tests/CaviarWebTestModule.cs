using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Caviar.EntityFrameworkCore;
using Caviar.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Caviar.Web.Tests
{
    [DependsOn(
        typeof(CaviarWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class CaviarWebTestModule : AbpModule
    {
        public CaviarWebTestModule(CaviarEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CaviarWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(CaviarWebMvcModule).Assembly);
        }
    }
}