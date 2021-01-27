using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.REST_API
{
    public class HttpClientApiKeyDelegatingHandler
       : DelegatingHandler
    {

        public HttpClientApiKeyDelegatingHandler()
        {
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var api_key = "api-key";
            //Instead of hardcoding the value here, I should get it from app settings
            var api_keyValue = "API-1UOLMM7RVIWZ0ML";

            if (!request.Headers.Contains(api_key))
            {
                request.Headers.Add(api_key, api_keyValue);
            }
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
