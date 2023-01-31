// Copyright (c) BeiYinZhiNian (1031622947@qq.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace Caviar.Dto
{
    public class CaviarPagedResultRequestDto : PagedResultRequestDto
    {
        public override int SkipCount { get => base.SkipCount; set => base.SkipCount = value - 1; }
    }
}
