using System.Threading.Tasks;
using MarketingBox.PasswordApi.Domain.Models;

namespace MarketingBox.PasswordApi.Services.Interfaces
{
    public interface IPasswordRecoveryNoSqlService
    {
        PasswordRecovery GetEntity(string token);
        Task DeleteEntityAsync(string id);
        Task UpsertEntityAsync(string id, string token, string tenantId);
    }
}