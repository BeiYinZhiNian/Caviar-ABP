// Copyright (c) BeiYinZhiNian (1031622947@qq.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Caviar.Authorization;

namespace Caviar
{
    [DependsOn(
        typeof(CaviarCoreModule),
        typeof(AbpAutoMapperModule))]
    public class CaviarApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<CaviarAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(CaviarApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
