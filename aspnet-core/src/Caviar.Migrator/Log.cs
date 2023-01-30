// Copyright (c) BeiYinZhiNian (1031622947@qq.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Abp.Dependency;
using Abp.Timing;
using Castle.Core.Logging;

namespace Caviar.Migrator
{
    public class Log : ITransientDependency
    {
        public ILogger Logger { get; set; }

        public Log()
        {
            Logger = NullLogger.Instance;
        }

        public void Write(string text)
        {
            Console.WriteLine(Clock.Now.ToString("yyyy-MM-dd HH:mm:ss") + " | " + text);
            Logger.Info(text);
        }
    }
}
