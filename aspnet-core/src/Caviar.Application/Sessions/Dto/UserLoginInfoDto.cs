// Copyright (c) BeiYinZhiNian (1031622947@qq.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Caviar.Authorization.Users;
using Caviar.Users.Dto;

namespace Caviar.Sessions.Dto
{
    [AutoMapFrom(typeof(User))]
    public class UserLoginInfoDto : UserDto
    {
        /// <summary>
        /// 所有权限
        /// </summary>
        public List<(string key, string value)> Permissions { get; set; }
    }
}
