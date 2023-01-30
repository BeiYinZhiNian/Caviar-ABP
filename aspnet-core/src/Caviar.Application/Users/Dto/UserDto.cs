// Copyright (c) BeiYinZhiNian (1031622947@qq.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using Caviar.Authorization.Users;

namespace Caviar.Users.Dto
{
    [AutoMapFrom(typeof(User))]
    public class UserDto : EntityDto<long>
    {
        public string UserName => PhoneNumber;

        [Required]
        [StringLength(AbpUserBase.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^1[3456789]\d{9}$", ErrorMessage = "请输入正确的手机号")]
        [StringLength(AbpUserBase.MaxPhoneNumberLength)]
        public string PhoneNumber { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreationTime { get; set; }

        public string[] RoleNames { get; set; }
    }
}
