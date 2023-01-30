// Copyright (c) BeiYinZhiNian (1031622947@qq.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Linq;
using Abp.Authorization;
using Abp.Authorization.Roles;
using AutoMapper;
using Caviar.Authorization.Roles;

namespace Caviar.Roles.Dto
{
    public class RoleMapProfile : Profile
    {
        public RoleMapProfile()
        {
            // Role and permission
            CreateMap<Permission, string>().ConvertUsing(r => r.Name);
            CreateMap<RolePermissionSetting, string>().ConvertUsing(r => r.Name);

            CreateMap<CreateRoleDto, Role>();

            CreateMap<RoleDto, Role>()
                .ForMember(x => x.CreationTime, opt => opt.Ignore()); ;

            CreateMap<Role, RoleDto>().ForMember(x => x.GrantedPermissions,
                opt => opt.MapFrom(x => x.Permissions.Where(p => p.IsGranted)));

            CreateMap<Role, RoleListDto>();
            CreateMap<Role, RoleEditDto>();
            CreateMap<Permission, FlatPermissionDto>();
        }
    }
}
