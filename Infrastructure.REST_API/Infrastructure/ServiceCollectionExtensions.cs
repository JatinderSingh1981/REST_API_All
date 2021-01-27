using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using Repository.REST_API;
using System;
using System.Net.Http;

namespace Infrastructure.REST_API
{
    //public static class ServiceCollectionExtensions
    //{
    //    // Adds all Http client services
    //    public static IServiceCollection AddHttpClientServices(this IServiceCollection services, 
    //        IConfiguration configuration)
    //    {
    //        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

    //        //register delegating handlers
    //        services.AddTransient<HttpClientApiKeyDelegatingHandler>();

    //        //add http client services
    //        services.AddHttpClient<IProductRepository, ProductRepository>()
    //               .SetHandlerLifetime(TimeSpan.FromMinutes(5))  //Sample. Default lifetime is 2 minutes
    //               .AddHttpMessageHandler<HttpClientApiKeyDelegatingHandler>()
    //               .AddPolicyHandler(GetRetryPolicy())
    //               .AddPolicyHandler(GetCircuitBreakerPolicy());

    //        return services;
    //    }

    //    private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
    //    {
    //        return HttpPolicyExtensions
    //            .HandleTransientHttpError()
    //            .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
    //            .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2,
    //                                                                        retryAttempt)));
    //    }

    //    private static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
    //    {
    //        return HttpPolicyExtensions
    //            .HandleTransientHttpError()
    //            .CircuitBreakerAsync(5, TimeSpan.FromSeconds(30));
    //    }
    //}
}
