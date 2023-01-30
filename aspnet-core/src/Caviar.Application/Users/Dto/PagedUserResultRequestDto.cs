// Copyright (c) BeiYinZhiNian (1031622947@qq.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Abp.Application.Services.Dto;

namespace Caviar.Users.Dto
{
    //custom PagedResultRequestDto
    public class PagedUserResultRequestDto : PagedResultRequestDto
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int[] RoleIds { get; set; }
    }
}
