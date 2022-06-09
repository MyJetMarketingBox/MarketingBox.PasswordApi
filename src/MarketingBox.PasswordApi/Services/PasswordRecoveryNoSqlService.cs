using System;
using System.Linq;
using System.Threading.Tasks;
using MarketingBox.PasswordApi.Domain.Models;
using MarketingBox.PasswordApi.Services.Interfaces;
using MarketingBox.Sdk.Common.Exceptions;
using Microsoft.Extensions.Logging;
using MyNoSqlServer.Abstractions;

namespace MarketingBox.PasswordApi.Services
{
    public class PasswordRecoveryNoSqlService : IPasswordRecoveryNoSqlService
    {
        private readonly IMyNoSqlServerDataWriter<PasswordRecoveryNoSql> _dataWriter;
        private readonly IMyNoSqlServerDataReader<PasswordRecoveryNoSql> _dataReader;
        private readonly ILogger<PasswordRecoveryNoSqlService> _logger;

        public PasswordRecoveryNoSqlService(
            IMyNoSqlServerDataWriter<PasswordRecoveryNoSql> dataWriter,
            IMyNoSqlServerDataReader<PasswordRecoveryNoSql> dataReader,
            ILogger<PasswordRecoveryNoSqlService> logger)
        {
            _dataWriter = dataWriter;
            _dataReader = dataReader;
            _logger = logger;
        }

        public PasswordRecovery GetEntity(string token)
        {
            var cachedEntities = _dataReader.Get(
                PasswordRecoveryNoSql.GeneratePartitionKey());
            var entity = cachedEntities.FirstOrDefault(e => e.Entity.Token == token)?.Entity;

            if (entity != null && entity.ExpiredDate >= DateTime.UtcNow) 
                return entity;

            var error = $"Deny password recovery with token: {token}.";
            _logger.LogInformation(error);
            throw new BadRequestException(error);
        }

        public async Task DeleteEntityAsync(string id)
        {
            await _dataWriter.DeleteAsync(
                PasswordRecoveryNoSql.GeneratePartitionKey(),
                PasswordRecoveryNoSql.GenerateRowKey(id));
        }

        public async Task UpsertEntityAsync(string id, string token, string tenantId)
        {
            await _dataWriter.CleanAndKeepMaxPartitions(Program.Settings.RecoveryCacheLength);
            
            await _dataWriter.InsertOrReplaceAsync(
                PasswordRecoveryNoSql.Create(new()
                {
                    Token = token,
                    TenantId = tenantId,
                    ExpiredDate = DateTime.UtcNow.AddHours(Program.Settings.RecoveryTokenLifetimeInHours),
                    UserId = id
                }));
        }
    }
}