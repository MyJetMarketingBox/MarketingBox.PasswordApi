using JetBrains.Annotations;
using MyJetWallet.Sdk.Grpc;

namespace MarketingBox.PasswordApi.Client
{
    [UsedImplicitly]
    public class AuthApiClientFactory: MyGrpcClientFactory
    {
        public AuthApiClientFactory(string grpcServiceUrl) : base(grpcServiceUrl)
        {
        }
    }
}
