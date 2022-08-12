using System;
using Microsoft.Extensions.DependencyInjection;

namespace ServiceDecorators.Extensions;

public static class IServiceCollectionExtensions
{
    public static void AddScopedWithDecorator<TDecoratedInterface, TDecoratedImplementation>(this IServiceCollection services, params Type[] decorators)
        where TDecoratedInterface : class
        where TDecoratedImplementation : class, TDecoratedInterface
    {
        services.AddScoped<TDecoratedImplementation>();
        services.AddScoped<TDecoratedInterface>(provider =>
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
        });

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