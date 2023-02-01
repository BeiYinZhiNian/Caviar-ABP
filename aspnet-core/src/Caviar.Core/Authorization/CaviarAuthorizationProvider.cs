// Copyright (c) BeiYinZhiNian (1031622947@qq.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Reflection;
using System;
using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace Caviar.Authorization
{
    public class CaviarAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            var permissionNamesType = typeof(PermissionNames);
            FieldInfo[] fis = permissionNamesType.GetFields();  // 注意，这里不能有任何选项，否则将无法获取到const常量
            foreach (var fieldInfo in fis)
            {
                var nameArr = fieldInfo.Name.Split('_');
                if (nameArr.Length <= 1) throw new Exception("权限命名不符合规则，无法自动加入");
                if (nameArr[1] == "Tenants")
                {
                    context.CreatePermission(fieldInfo.Name, L(nameArr[nameArr.Length - 1]), multiTenancySides: MultiTenancySides.Host);
                }
                else
                {
                    context.CreatePermission(fieldInfo.Name, L(nameArr[nameArr.Length - 1]));
                }
            }
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, CaviarConsts.LocalizationSourceName);
        }
    }
}
