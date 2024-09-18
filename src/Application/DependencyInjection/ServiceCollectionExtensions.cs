using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using PromotionEngine.Application.Infrastructure.Repositories;
using PromotionEngine.Application.Mappings;
using PromotionEngine.Application.Shared.Persistence;
using System.Reflection;

namespace PromotionEngine.Application.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddTransient(_ => new DatabaseConnection(configuration.GetConnectionString("DefaultConnection")!.ToString()));
        services.AddScoped<IPromotionsRepository, PromotionsRepository>();
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MappingProfile());
        });
        

        IMapper mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);
        return services;
    }
}
