﻿// Copyright (c) BeiYinZhiNian (1031622947@qq.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Auditing;
using Abp.AutoMapper;

namespace Caviar.Journals.Dto
{
    [AutoMapFrom(typeof(AuditLog))]
    public class AuditLogDto : AuditLog
    {
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
    }
}
