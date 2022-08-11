namespace ValidationDecorator.Services;

public class ApplicationServiceValidationDecorator : IApplicationService
{
    private readonly IApplicationService _service;

    public ApplicationServiceValidationDecorator(IApplicationService service) => _service = service;

    public ApplicationResponse Get(ApplicationRequest ApplicationRequest)
    {
        // Validate ApplicationRequest
        if (ApplicationRequest == null) throw new ArgumentNullException();

 
        return _service.Get(ApplicationRequest);
    }
}