// Copyright (c) BeiYinZhiNian (1031622947@qq.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Abp.Auditing;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.Domain.Repositories;
using Abp.Localization;
using Caviar.Sessions.Dto;

namespace Caviar.Sessions
{
    public class SessionAppService : CaviarAppServiceBase, ISessionAppService
    {
        private readonly IRepository<RolePermissionSetting, long> _permissionRepository;
        private readonly IRepository<UserRole, long> _userRoleRepository;
        public SessionAppService(IRepository<RolePermissionSetting, long> permissionRepository, IRepository<UserRole, long> userRoleRepository)
        {
            _permissionRepository = permissionRepository;
            _userRoleRepository = userRoleRepository;
        }
        [DisableAuditing]
        public async Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations()
        {
            var output = new GetCurrentLoginInformationsOutput
            {
                Application = new ApplicationInfoDto
                {
                    Version = AppVersionHelper.Version,
                    ReleaseDate = AppVersionHelper.ReleaseDate,
                    Features = new Dictionary<string, bool>()
                }
            };

            if (AbpSession.TenantId.HasValue)
            {
                output.Tenant = ObjectMapper.Map<TenantLoginInfoDto>(await GetCurrentTenantAsync());
            }

            if (AbpSession.UserId.HasValue)
            {
                output.User = ObjectMapper.Map<UserLoginInfoDto>(await GetCurrentUserAsync());
                var roleIds = _userRoleRepository.GetAllList(u => u.UserId == output.User.Id).Select(u => u.Id);
                output.User.Permissions = _permissionRepository.GetAllList(u => roleIds.Contains(u.RoleId) && u.IsGranted).Select(u =>
                {
                    var displayName = u.Name.Split('_').Last();
                    return (u.Name, L(displayName));
                }).ToList();
            }

            return output;
        }
    }
}
