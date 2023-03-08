// Copyright (c) BeiYinZhiNian (1031622947@qq.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Auditing;
using Abp.Auditing;
using Castle.Core.Logging;
using Microsoft.AspNetCore.Http;

namespace Caviar.Extensions
{
    public class WebClientInfoProviderFix : IClientInfoProvider
    {
        public string BrowserInfo => GetBrowserInfo();

        public string ClientIpAddress => GetClientIpAddress();

        public string ComputerName => GetComputerName();

        public ILogger Logger { get; set; }

        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly HttpContext _httpContext;

        /// <summary>
        /// Creates a new <see cref="HttpContextClientInfoProvider"/>.
        /// </summary>
        public WebClientInfoProviderFix(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _httpContext = httpContextAccessor.HttpContext;

            Logger = NullLogger.Instance;
        }

        protected virtual string GetBrowserInfo()
        {
            var httpContext = _httpContextAccessor.HttpContext ?? _httpContext;
            return httpContext?.Request?.Headers?["User-Agent"];
        }

        protected virtual string GetClientIpAddress()
        {
            try
            {
                var httpContext = _httpContextAccessor.HttpContext ?? _httpContext;

                var headers = httpContext?.Request.Headers;
                if (headers != null && headers.ContainsKey("X-Forwarded-For"))
                {
                    httpContext.Connection.RemoteIpAddress = IPAddress.Parse(headers["X-Forwarded-For"].ToString().Split(',', StringSplitOptions.RemoveEmptyEntries)[0]);
                }
                return httpContext?.Connection?.RemoteIpAddress?.ToString();
            }
            catch (Exception ex)
            {
                Logger.Warn(ex.ToString());
            }
            return null;
        }

        protected virtual string GetComputerName()
        {
            return null; //TODO: Implement!
        }
    }


}
