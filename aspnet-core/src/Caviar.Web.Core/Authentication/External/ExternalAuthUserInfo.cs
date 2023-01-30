// Copyright (c) BeiYinZhiNian (1031622947@qq.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Caviar.Authentication.External
{
    public class ExternalAuthUserInfo
    {
        public string ProviderKey { get; set; }

        public string Name { get; set; }

        public string EmailAddress { get; set; }

        public string Surname { get; set; }

        public string Provider { get; set; }
    }
}
