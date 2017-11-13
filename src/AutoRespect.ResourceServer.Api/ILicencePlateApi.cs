using System.Collections.Generic;
using System.Threading.Tasks;
using AutoRespect.Infrastructure.Api.Design;
using AutoRespect.Infrastructure.DI.Design;
using AutoRespect.Infrastructure.DI.Design.Attributes;
using AutoRespect.Infrastructure.Errors.Design;
using AutoRespect.Infrastructure.ServiceDiscovery.Design.Microservices;
using AutoRespect.ResourceServer.DataTransfer.Request;
using AutoRespect.ResourceServer.DataTransfer.Response;

namespace AutoRespect.ResourceServer.Api
{
    public interface ILicencePlateApi
    {
        Task<R<List<LicencePlateResponse>>> Get(string token);
        Task<R<LicencePlateResponse>> Get(string token, int licencePlateId);
        Task<R<IdResponse>> Add(string token, AddLicencePlateRequest request);
    }

    [DI(LifeCycle.Singleton)]
    public class LicencePlateApi : ILicencePlateApi
    {
        private readonly IHttp http;
        private readonly IEndpointGetter endpointGetter;
        private readonly string endpoint;

        public LicencePlateApi(
            IHttp http,
            IEndpointGetter endpointGetter)
        {
            this.http = http;
            this.endpointGetter = endpointGetter;
            this.endpoint = endpointGetter.Get(MicroserviceType.ResourceServer).Result;
        }

        public Task<R<IdResponse>> Add(string token, AddLicencePlateRequest request) =>
            http.Post<AddLicencePlateRequest, IdResponse>(
                uri: $"{endpoint}/api/v1/LicencePlate/",
                body: request,
                settings: HttpSettingsExtension.Create(token)
            );

        public Task<R<List<LicencePlateResponse>>> Get(string token) =>
            http.Get<List<LicencePlateResponse>>(
                uri: $"{endpoint}/api/v1/LicencePlate/",
                settings: HttpSettingsExtension.Create(token)

            );

        public Task<R<LicencePlateResponse>> Get(string token, int licencePlateId) =>
            http.Get<LicencePlateResponse>(
                uri: $"{endpoint}/api/v1/LicencePlate/{licencePlateId}",
                settings: HttpSettingsExtension.Create(token)

            );

    }
}
