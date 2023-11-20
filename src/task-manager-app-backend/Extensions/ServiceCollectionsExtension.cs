namespace task_manager_app_backend.Extensions;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddScopedByInterface<T>(this IServiceCollection services)
    {
        var types = typeof(T).Assembly
            .GetTypes()
            .Where(myType => myType.IsClass
                    && !myType.IsAbstract
                    && myType.GetInterfaces()
                        .Any(@interface => @interface == typeof(T)));

        foreach (var type in types)
            services.AddScoped(type);

        return services;
    }
}

