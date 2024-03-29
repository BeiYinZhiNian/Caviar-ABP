﻿// Copyright (c) BeiYinZhiNian (1031622947@qq.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Abp.Application.Services.Dto;
using Caviar.Dto;

namespace Caviar.Roles.Dto
{
    public class PagedRoleResultRequestDto : CaviarPagedResultRequestDto
    {
        public string Name { get; set; }
    }
}

