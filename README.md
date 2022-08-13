# Service Decorators

## TL;DR
We can decorate our service layer ([ApplicationServiceValidationDecorator](../master/Source/Services/ApplicationServiceValidationDecorator.cs), [ApplicationServiceCacheDecorator](../master/Source/Services/ApplicationServiceCacheDecorator.cs)) with dependency injection support ([IServiceCollectionExtensions](../master/Source/Extensions/IServiceCollectionExtensions.cs)) for more flexibility and modularity using the .NET framework without any additional packages. 

## Summary
The service layer in a typical application can suffer from bloat when we begin adding additional functionality aside from the usual business logic over top of a repository. We find ourselves requiring validation rules, a caching strategy, etc. Rather than using a base class to handle generalized functionality, we can utilize the decorator design pattern. This follows more closely to SOLID principles by allowing us to add additional functionality over top of our services without having to change our existing code.  

## More information from Microsoft
[Design Patterns: Decorator](https://docs.microsoft.com/en-us/shows/visual-studio-toolbox/design-patterns-decorator)

## More information from additional resources
[Cached Repository Pattern](https://ardalis.com/introducing-the-cachedrepository-pattern/)
