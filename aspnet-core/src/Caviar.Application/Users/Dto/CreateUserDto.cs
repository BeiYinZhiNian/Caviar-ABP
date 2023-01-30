// Copyright (c) BeiYinZhiNian (1031622947@qq.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.ComponentModel.DataAnnotations;
using Abp.Auditing;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using Caviar.Authorization.Users;

namespace Caviar.Users.Dto
{
    [AutoMapTo(typeof(User))]
    public class CreateUserDto : IShouldNormalize
    {
        public string UserName => PhoneNumber;

        [Required]
        [StringLength(AbpUserBase.MaxNameLength)]
        public string Name { get; set; }
        [RegularExpression(@"^1[3456789]\d{9}$", ErrorMessage = "请输入正确的手机号")]
        [StringLength(AbpUserBase.MaxPhoneNumberLength)]
        [Required]
        public string PhoneNumber { get; set; }

        public bool IsActive { get; set; }

        public string[] RoleNames { get; set; }

        [Required]
        [StringLength(AbpUserBase.MaxPlainPasswordLength)]
        [DisableAuditing]
        public string Password { get; set; }

        public void Normalize()
        {
            if (RoleNames == null)
            {
                RoleNames = new string[0];
            }
        }
    }
}
