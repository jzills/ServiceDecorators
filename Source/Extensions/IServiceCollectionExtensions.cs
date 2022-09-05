namespace ServiceDecorators.Extensions;

public static partial class IServiceCollectionExtensions
{
    public static void AddSingletonWithDecorators<TDecoratedInterface, TDecoratedImplementation>(
        this IServiceCollection services,
        params Type[] decorators
    ) 
        where TDecoratedInterface : class
        where TDecoratedImplementation : class, TDecoratedInterface
            =>  services.AddWithDecorators<TDecoratedInterface, TDecoratedImplementation>(
                    ServiceLifetime.Singleton, 
                    decorators
                );

    public static void AddScopedWithDecorators<TDecoratedInterface, TDecoratedImplementation>(
        this IServiceCollection services,
        params Type[] decorators
    ) 
        where TDecoratedInterface : class
        where TDecoratedImplementation : class, TDecoratedInterface
            =>  services.AddWithDecorators<TDecoratedInterface, TDecoratedImplementation>(
                    ServiceLifetime.Scoped, 
                    decorators
                );

    public static void AddTransientWithDecorators<TDecoratedInterface, TDecoratedImplementation>(
        this IServiceCollection services,
        params Type[] decorators
    ) 
        where TDecoratedInterface : class
        where TDecoratedImplementation : class, TDecoratedInterface
            =>  services.AddWithDecorators<TDecoratedInterface, TDecoratedImplementation>(
                    ServiceLifetime.Transient, 
                    decorators
                );

    public static void AddWithDecorators<TDecoratedInterface, TDecoratedImplementation>(
        this IServiceCollection services, 
        ServiceLifetime serviceLifetime = ServiceLifetime.Scoped,
        params Type[] decorators
    )
        where TDecoratedInterface : class
        where TDecoratedImplementation : class, TDecoratedInterface
    {
        Func<IServiceProvider, TDecoratedInterface> implementationFactory = provider =>
        {
            TDecoratedInterface implementation = (TDecoratedInterface)provider
                .GetRequiredService<TDecoratedImplementation>();
            
            foreach (var decorator in decorators)
            {
                var activatorParameters = GetActivatorParameters(decorator, implementation, provider);
                implementation = (TDecoratedInterface)Activator
                    .CreateInstance(decorator, activatorParameters)!;
            }

            return implementation;
        };

        switch (serviceLifetime)
        {
            case ServiceLifetime.Singleton:
                services.AddSingleton<TDecoratedImplementation>();
                services.AddSingleton<TDecoratedInterface>(implementationFactory);
                break;
            case ServiceLifetime.Scoped:
                services.AddScoped<TDecoratedImplementation>();
                services.AddScoped<TDecoratedInterface>(implementationFactory);
                break;
            case ServiceLifetime.Transient:
                services.AddTransient<TDecoratedImplementation>();
                services.AddTransient<TDecoratedInterface>(implementationFactory);
                break;
            default:
                throw new NotSupportedException("The specified ServiceLifetime is not supported.");
        }

        object[]? GetActivatorParameters(Type decorator, TDecoratedInterface implementation, IServiceProvider provider)
        {
            var constructor = decorator.GetConstructors()[0];
            var constructorParameters = constructor.GetParameters();
            var activatorParameters = new object[constructorParameters.Length];

            for (var i = 0; i < constructorParameters.Length; ++i)
            {
                if (constructorParameters[i].ParameterType == typeof(TDecoratedInterface))
                {
                    activatorParameters[i] = implementation;
                }
                else
                {
                    activatorParameters[i] = provider
                        .GetRequiredService(constructorParameters[i].ParameterType);
                }
            }

            return activatorParameters;
        }
    }
}