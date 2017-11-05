using System;
using System.Threading.Tasks;
using AutoRespect.AuthorizationServer.DataTransfer;
using AutoRespect.Infrastructure.Api.Design;
using AutoRespect.Infrastructure.DI.Design;
using AutoRespect.Infrastructure.DI.Design.Attributes;
using AutoRespect.Infrastructure.Errors.Design;
using AutoRespect.Infrastructure.ServiceDiscovery.Design.Microservices;

namespace AutoRespect.AuthorizationServer.Api
{

    public interface IAccountApi
    {
        Task<R<string>> SignIn(SignInRequest request);
        Task<R<string>> Register(RegisterRequest request);
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

        public async Task<R<string>> Register(RegisterRequest request)
        {
            var uri = $"{endpoint}/api/v1/Registration/";
            var response = await http.Post<RegisterRequest, string>(uri, request);

            return response;
        }

        public async Task<R<string>> SignIn(SignInRequest request)
        {
            var uri = $"{endpoint}/api/v1/Login/";
            var response = await http.Post<SignInRequest, string>(uri, request);

            return response;
        }
    }
}
