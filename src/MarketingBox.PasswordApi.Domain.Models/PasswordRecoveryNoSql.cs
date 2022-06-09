using MyNoSqlServer.Abstractions;

namespace MarketingBox.PasswordApi.Domain.Models
{
    public class PasswordRecoveryNoSql : MyNoSqlDbEntity
    {
        public const string TableName = "marketingbox-user-password-recovery";
        public static string GeneratePartitionKey() => "PasswordRecovery";
        public static string GenerateRowKey(string userId) => $"{userId}";
        public PasswordRecovery Entity { get; set; }
        
        public static PasswordRecoveryNoSql Create(PasswordRecovery entity)
        {
            return new PasswordRecoveryNoSql()
            {
                PartitionKey = GeneratePartitionKey(),
                RowKey = GenerateRowKey(entity.UserId),
                Entity = entity,
                Expires = entity.ExpiredDate
            };
        }
    }
}