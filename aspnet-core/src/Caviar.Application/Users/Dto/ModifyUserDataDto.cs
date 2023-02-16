// Copyright (c) BeiYinZhiNian (1031622947@qq.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using Caviar.Authorization.Users;

namespace Caviar.Users.Dto
{
    [AutoMapFrom(typeof(User))]
    public class ModifyUserDataDto : EntityDto<long>
    {
        public string UserName => PhoneNumber;

        [Required]
        [StringLength(AbpUserBase.MaxNameLength)]
        public string Name { get; set; }
        [RegularExpression(@"^1[3456789]\d{9}$", ErrorMessage = "请输入正确的手机号")]
        [StringLength(AbpUserBase.MaxPhoneNumberLength)]
        [Required]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        [StringLength(AbpUserBase.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }
    }
}
