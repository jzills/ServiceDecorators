namespace ValidationDecorator.Extensions;

public static class IServiceCollectionExtensions
{
    public static void AddDecorator<TDecoratedInterface, TDecoratedImplementation>(this IServiceCollection services, params Type[] decorators)
        where TDecoratedInterface : class
        where TDecoratedImplementation : class, TDecoratedInterface
    {
        services.AddScoped<TDecoratedImplementation>();
        services.AddScoped<TDecoratedInterface>(provider =>
        {
            TDecoratedInterface implementation = (TDecoratedInterface)provider.GetRequiredService<TDecoratedImplementation>();
            foreach (var decorator in decorators)
            {
                implementation = (TDecoratedInterface)Activator.CreateInstance(decorator, implementation)!;
            }

            return implementation;
        });
    }
}