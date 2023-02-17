// Copyright (c) BeiYinZhiNian (1031622947@qq.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization.Users;
using Abp.Collections.Extensions;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Linq;
using Abp.Linq.Extensions;
using Caviar.Authorization;
using Caviar.Journals.Dto;

namespace Caviar.Journals
{
    public class JournalAppService : CaviarAppServiceBase
    {
        private readonly IRepository<UserLoginAttempt, long> _repository;
        private readonly AbpLoginResultTypeHelper _abpLoginResultTypeHelper;
        public JournalAppService(IRepository<UserLoginAttempt, long> repository, AbpLoginResultTypeHelper abpLoginResultTypeHelper)
        {
            _repository = repository;
            _abpLoginResultTypeHelper = abpLoginResultTypeHelper;
        }

        public async Task<PagedResultDto<UserLoginAttemptDto>> GetAllUserLoginLog(PagedLogResultRequestDto input)
        {
            var query = _repository.GetAllIncluding()
                .WhereIf(!string.IsNullOrEmpty(input.Key), x => x.UserNameOrEmailAddress.Contains(input.Key))
                .WhereIf(input.Time != null && input.Time.Length == 2, x => x.CreationTime >= input.Time[0] && x.CreationTime <= input.Time[1])
                .WhereIf(input.LoginResult != null, x => input.LoginResult.Value ? x.Result == Abp.Authorization.AbpLoginResultType.Success : x.Result != Abp.Authorization.AbpLoginResultType.Success);
            int totalCount = await NullAsyncQueryableExecuter.Instance.CountAsync(query).ConfigureAwait(continueOnCapturedContext: false);
            query = query.OrderByDescending(r => r.CreationTime);
            query = query.PageBy(input);
            var result = new PagedResultDto<UserLoginAttemptDto>(totalCount, (await NullAsyncQueryableExecuter.Instance.ToListAsync(query).ConfigureAwait(continueOnCapturedContext: false)).Select(new Func<UserLoginAttempt, UserLoginAttemptDto>(u => ObjectMapper.Map<UserLoginAttemptDto>(u))).ToList());
            foreach (var item in result.Items)
            {
                if (item.Result == Abp.Authorization.AbpLoginResultType.Success)
                {
                    item.ResultMsg = "登录成功";
                }
                else
                {
                    item.ResultMsg = _abpLoginResultTypeHelper.CreateLocalizedMessageForFailedLoginAttempt(item.Result, item.UserNameOrEmailAddress, item.TenancyName);
                }
            }
            return result;
        }
    }
}
