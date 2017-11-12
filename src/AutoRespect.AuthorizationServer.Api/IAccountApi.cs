using System.Threading.Tasks;
using AutoRespect.AuthorizationServer.DataTransfer.Request;
using AutoRespect.AuthorizationServer.DataTransfer.Response;
using AutoRespect.Infrastructure.Api.Design;
using AutoRespect.Infrastructure.DI.Design;
using AutoRespect.Infrastructure.DI.Design.Attributes;
using AutoRespect.Infrastructure.Errors.Design;
using AutoRespect.Infrastructure.ServiceDiscovery.Design.Microservices;

namespace AutoRespect.AuthorizationServer.Api
{

    public interface IAccountApi
    {
        Task<R<TokensResponse>> SignIn(SignInRequest request);
        Task<R<TokensResponse>> Register(RegisterRequest request);
    }

    [DI(LifeCycle.Singleton)]
    public class AccountApi : IAccountApi
    {
        private readonly IHttp http;
        private readonly IEndpointGetter endpointGetter;
        private readonly string endpoint;

        public AccountApi(
            IHttp http,
            IEndpointGetter endpointGetter)
        {
            this.http = http;
            this.endpointGetter = endpointGetter;

            endpoint = endpointGetter.Get(MicroserviceType.IdentityServer).Result;
        }

        public async Task<R<TokensResponse>> Register(RegisterRequest request)
        {
            var uri = $"{endpoint}/api/v1/Registration/";
            var response = await http.Post<RegisterRequest, TokensResponse>(uri, request);

            return response;
        }

        public async Task<R<TokensResponse>> SignIn(SignInRequest request)
        {
            var uri = $"{endpoint}/api/v1/Login/";
            var response = await http.Post<SignInRequest, TokensResponse>(uri, request);

            return response;
        }
    }
}
