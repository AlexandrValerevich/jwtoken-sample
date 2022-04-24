using Microsoft.OpenApi.Models;

namespace JwtAuthentification.Infrastructure.DependencyInjection;

public static class SwaggerConfiguration
{
    public static IServiceCollection AddConfiguredSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            var security = new OpenApiSecurityRequirement()
            {
                {new OpenApiSecurityScheme(){ Name = "Bearer" }, Array.Empty<string>()}
            };

            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Description = "Jwt Authorization header using the bearer scheme",
                Name = "Authorizaton",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
            });

            options.AddSecurityRequirement(security);
        });

        return services;
    }
}
