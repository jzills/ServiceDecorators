# Service Decorators

## TL;DR
The service layer in a typical application can suffer from bloat when we begin adding additional functionality aside from the usual business logic over top of a repository. We find ourselves requiring validation rules, a caching strategy, etc. Rather than using a base class to handle generalized functionality, we can utilize the decorator design pattern. This follows more closely to SOLID principles by allowing us to add additional functionality over top of our services without having to change our existing code.   

## Summary

## More information from Microsoft
[Design Patterns: Decorator](https://docs.microsoft.com/en-us/shows/visual-studio-toolbox/design-patterns-decorator)
