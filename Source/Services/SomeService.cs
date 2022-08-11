namespace ValidationDecorator.Services;

public class SomeRequest
{

}

public interface IApplicationService
{
    public void SomeMethod(SomeRequest request);
}

public class ApplicationService : IApplicationService
{
    public void SomeMethod(SomeRequest request)
    {
        throw new NotImplementedException();
    }
}

public class ApplicationServiceValidationDecorator : IApplicationService
{
    private readonly IApplicationService _service;

    public ApplicationServiceValidationDecorator(IApplicationService service) => _service = service;

    public void SomeMethod(SomeRequest request)
    {
        // validate request

        // no exceptions, ok, continue
        _service.SomeMethod(request);
    }
}

public class ApplicationServiceCacheDecorator : IApplicationService
{
    private readonly IApplicationService _service;

    public ApplicationServiceCacheDecorator(IApplicationService service) => _service = service;

    public void SomeMethod(SomeRequest request)
    {
        // cache request

        // no exceptions, ok, continue
        _service.SomeMethod(request);
    }
}