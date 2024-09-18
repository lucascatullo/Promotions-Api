
using Asp.Versioning;
using Microsoft.Extensions.DependencyInjection;

namespace PromotionEngine.Application.Shared.Extensions;

public static class ServiceExtension
{
    public static IServiceCollection AddAPIVersionConfig(this IServiceCollection service)
    {
        service.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ReportApiVersions = true;
            options.ApiVersionReader = ApiVersionReader.Combine(
                new UrlSegmentApiVersionReader(),
                new HeaderApiVersionReader("X-Api-Version")
            );
        }).AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });
        return service;
    } 
}
