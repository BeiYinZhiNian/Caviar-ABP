// Copyright (c) BeiYinZhiNian (1031622947@qq.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Auditing;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.Collections.Extensions;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Linq;
using Abp.Linq.Extensions;
using Caviar.Authorization;
using Caviar.Authorization.Users;
using Caviar.Journals.Dto;

namespace Caviar.Journals
{
    [AbpAuthorize(PermissionNames.SystemSettings_Journals)]
    public class JournalAppService : CaviarAppServiceBase
    {
        private readonly IRepository<UserLoginAttempt, long> _repository;
        private readonly IRepository<AuditLog, long> _auditLogRepository;
        private readonly ICaviarRepository _caviarRepository;
        private readonly AbpLoginResultTypeHelper _abpLoginResultTypeHelper;
        public JournalAppService(IRepository<UserLoginAttempt, long> repository, AbpLoginResultTypeHelper abpLoginResultTypeHelper, IRepository<AuditLog, long> auditLogRepository, ICaviarRepository caviarRepository)
        {
            _repository = repository;
            _abpLoginResultTypeHelper = abpLoginResultTypeHelper;
            _auditLogRepository = auditLogRepository;
            _caviarRepository = caviarRepository;
        }
        [AbpAuthorize(PermissionNames.SystemSettings_Journals_Login)]
        public async Task<PagedResultDto<UserLoginAttemptDto>> GetAllUserLoginLog(PagedLogResultRequestDto input)
        {
            var query = _repository.GetAllIncluding()
                .WhereIf(!string.IsNullOrEmpty(input.Key), x => x.UserNameOrEmailAddress.Contains(input.Key))
                .WhereIf(input.Time != null && input.Time.Length == 2, x => x.CreationTime >= input.Time[0] && x.CreationTime <= input.Time[1])
                .WhereIf(input.Result != null, x => input.Result.Value ? x.Result == Abp.Authorization.AbpLoginResultType.Success : x.Result != Abp.Authorization.AbpLoginResultType.Success);
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
        [AbpAuthorize(PermissionNames.SystemSettings_Journals_AuditLog)]
        public async Task<PagedResultDto<AuditLogDto>> GetAllAuditLog(PagedLogResultRequestDto input)
        {
            var userId = string.IsNullOrEmpty(input.Key) ? null : _caviarRepository.Set<User, long>().GetAllIncluding().Where(u => u.PhoneNumber.Contains(input.Key) || u.Name.Contains(input.Key)).Select(u => u.Id);
            var query = _auditLogRepository.GetAllIncluding()
                .WhereIf(!string.IsNullOrEmpty(input.Key), x => userId.Contains(x.UserId.Value))
                .WhereIf(input.Time != null && input.Time.Length == 2, x => x.ExecutionTime >= input.Time[0] && x.ExecutionTime <= input.Time[1])
                .WhereIf(input.Result != null, x => input.Result.Value ? x.Exception == null : !string.IsNullOrEmpty(x.Exception));
            int totalCount = await NullAsyncQueryableExecuter.Instance.CountAsync(query).ConfigureAwait(continueOnCapturedContext: false);
            query = query.OrderByDescending(r => r.ExecutionTime);
            query = query.PageBy(input);
            var result = new PagedResultDto<AuditLogDto>(totalCount, (await NullAsyncQueryableExecuter.Instance.ToListAsync(query).ConfigureAwait(continueOnCapturedContext: false)).Select(new Func<AuditLog, AuditLogDto>(u => ObjectMapper.Map<AuditLogDto>(u))).ToList());
            foreach (var item in result.Items)
            {
                if (item.UserId != null)
                {
                    var user = _caviarRepository.Set<User, long>().FirstOrDefault(u => u.Id == item.UserId);
                    item.PhoneNumber = user?.PhoneNumber;
                    item.Name = user?.Name;
                }
            }
            return result;
        }
    }
}
