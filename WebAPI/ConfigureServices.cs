namespace WebAPI;

public static class ConfigureServices
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddCors();
        services.AddSwaggerGen();
        services.AddApiVersioning();
        services.AddVersionedApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });
        
        // services.AddScoped(provider =>
        // {
        //     var validationRules = provider.GetService<IEnumerable<FluentValidationRule>>();
        //     var loggerFactory = provider.GetService<ILoggerFactory>();
        //
        //     return new FluentValidationSchemaProcessor(provider, validationRules, loggerFactory);
        // });
        
        return services;
    }
}