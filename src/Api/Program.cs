
using Microsoft.OpenApi.Models;
using PromotionEngine.Application.DependencyInjection;
using System.Text.Json;
using System.Text.Json.Serialization;
using PromotionEngine.Application.Shared.Extensions;
var builder = WebApplication.CreateBuilder(args);



builder
    .Services
    .AddApplication(builder.Configuration)
    .AddAPIVersionConfig()
    .AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Promotion API - V1", Version = "v1.0" });
        c.SwaggerDoc("v2", new OpenApiInfo { Title = "Promotion API - V2", Version = "v2.0" });
    })
    .AddEndpointsApiExplorer()
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    });
builder.Services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
                                                            .AllowAnyMethod()
                                                             .AllowAnyHeader()));

builder.WebHost.UseUrls("http://0.0.0.0:80");
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    var descriptions = app.DescribeApiVersions();

    // Build a swagger endpoint for each discovered API version
    foreach (var description in descriptions)
    {
        var url = $"/swagger/{description.GroupName}/swagger.json";
        var name = description.GroupName.ToUpperInvariant();
        options.SwaggerEndpoint(url, name);
    }
});
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();
app.UseDeveloperExceptionPage();
await app.RunAsync();
