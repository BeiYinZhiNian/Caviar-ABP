// Copyright (c) BeiYinZhiNian (1031622947@qq.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Caviar.Authorization.Users;

namespace Caviar.Sessions.Dto
{
    [AutoMapFrom(typeof(User))]
    public class UserLoginInfoDto : EntityDto<long>
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string UserName { get; set; }

        public string EmailAddress { get; set; }
        /// <summary>
        /// 所有权限
        /// </summary>
        public string[] Permissions { get; set; }
    }
}
