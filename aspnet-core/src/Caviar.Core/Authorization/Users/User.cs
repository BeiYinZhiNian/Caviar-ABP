// Copyright (c) BeiYinZhiNian (1031622947@qq.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Authorization.Users;
using Abp.Extensions;

namespace Caviar.Authorization.Users
{
    public class User : AbpUser<User>
    {
        public const string DefaultPassword = "123qwe";
        public override string UserName
        {
            get => base.PhoneNumber;
            set => base.UserName = value;
        }
        [NotMapped]
        private new string Surname { get; set; }
        public static string CreateRandomPassword()
        {
            return Guid.NewGuid().ToString("N").Truncate(16);
        }
        public override void SetNormalizedNames()
        {
            NormalizedUserName = UserName.ToUpperInvariant();
            NormalizedEmailAddress = EmailAddress?.ToUpperInvariant();
        }
        public static User CreateTenantAdminUser(int tenantId, string name, string phoneNumber)
        {
            var user = new User
            {
                TenantId = tenantId,
                Name = name,
                UserName = phoneNumber,
                PhoneNumber = phoneNumber,
                Roles = new List<UserRole>()
            };

            user.SetNormalizedNames();

            return user;
        }
    }
}
