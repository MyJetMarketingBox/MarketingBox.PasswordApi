using JetBrains.Annotations;
using MyJetWallet.Sdk.Grpc;

namespace MarketingBox.PasswordApi.Client
{
    [UsedImplicitly]
    public class PasswordApiClientFactory: MyGrpcClientFactory
    {
        public PasswordApiClientFactory(string grpcServiceUrl) : base(grpcServiceUrl)
        {
        }
    }
}
