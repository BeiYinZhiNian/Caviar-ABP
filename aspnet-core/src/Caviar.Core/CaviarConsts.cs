// Copyright (c) BeiYinZhiNian (1031622947@qq.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Caviar.Debugging;

namespace Caviar
{
    public class CaviarConsts
    {
        public const string LocalizationSourceName = "Caviar-zh-Hans";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;

        public const string AdminPhoneNumber = "13034734324";

        public const string AdminName = "超级管理员";


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "0ec7b44436af4e92b50d826c64f5c389";
    }
}
