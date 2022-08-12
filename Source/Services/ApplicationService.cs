namespace ServiceDecorators.Services;

public interface IApplicationService
{
    ApplicationResponse Get(ApplicationRequest ApplicationRequest);
}

public class ApplicationService : IApplicationService
{
    public ApplicationResponse Get(ApplicationRequest ApplicationRequest) => 
        new ApplicationResponse { IsSuccess = true };
}