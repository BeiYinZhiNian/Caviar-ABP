// Copyright (c) BeiYinZhiNian (1031622947@qq.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Caviar.Sessions.Dto
{
    public class GetCurrentLoginInformationsOutput
    {
        public ApplicationInfoDto Application { get; set; }

        public UserLoginInfoDto User { get; set; }

        public TenantLoginInfoDto Tenant { get; set; }
    }
}
