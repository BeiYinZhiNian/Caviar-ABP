// Copyright (c) BeiYinZhiNian (1031622947@qq.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Caviar.Authentication.External
{
    public class ExternalLoginProviderInfo
    {
        public string Name { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public Type ProviderApiType { get; set; }

        public ExternalLoginProviderInfo(string name, string clientId, string clientSecret, Type providerApiType)
        {
            Name = name;
            ClientId = clientId;
            ClientSecret = clientSecret;
            ProviderApiType = providerApiType;
        }
    }
}
