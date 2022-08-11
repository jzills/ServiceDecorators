using Microsoft.Extensions.Caching.Memory;

namespace ValidationDecorator.Services;

public class ApplicationServiceCacheDecorator : IApplicationService
{
    private readonly IApplicationService _service;
    private readonly IMemoryCache _cache;

    public ApplicationServiceCacheDecorator(
        IApplicationService service,
        IMemoryCache cache
    ) => (_service, _cache) = (service, cache);

    public ApplicationResponse Get(ApplicationRequest request)
    {
        // Check cache
        if (_cache.TryGetValue<ApplicationResponse>(
            nameof(ApplicationResponse), 
            out var response
        ))
        {
            return response;
        }

        response = _service.Get(request);
        _cache.Set(nameof(ApplicationResponse), response);

        return response;
    }
}