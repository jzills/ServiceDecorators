namespace ValidationDecorator.Services;

public class ApplicationResponse
{
}

public class ApplicationRequest
{
}

public interface IApplicationService
{
    public ApplicationResponse Get(ApplicationRequest ApplicationRequest);
}

public class ApplicationService : IApplicationService
{
    public ApplicationResponse Get(ApplicationRequest ApplicationRequest) => new ApplicationResponse();
}