// Copyright (c) BeiYinZhiNian (1031622947@qq.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Authorization;
using Caviar.Dto;

namespace Caviar.Journals.Dto
{
    public class PagedLogResultRequestDto : CaviarPagedResultRequestDto
    {
        public string Key { get; set; }
        public DateTime?[] Time { get; set; }
        /// <summary>
        /// 登录结果
        /// </summary>
        public bool? LoginResult { get; set; }
    }
}
