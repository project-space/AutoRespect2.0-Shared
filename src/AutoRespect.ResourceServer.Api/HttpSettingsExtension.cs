using System.Collections.Generic;
using AutoRespect.Infrastructure.Api.Design;

namespace AutoRespect.ResourceServer.Api
{
    internal static class HttpSettingsExtension
    {
        public static HttpSettings Create(string token) =>
            new HttpSettings
            {
                Headers = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Authorization", $"Bearer token")
                }
            };
    }
}
