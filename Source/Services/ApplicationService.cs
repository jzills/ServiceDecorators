using Source.Data;

namespace Source.Services;

public interface IApplicationService
{
    ApplicationResponse Get(ApplicationRequest ApplicationRequest);
}

public class ApplicationService : IApplicationService
{
    private readonly ApplicationDbContext _context;

    public ApplicationService(ApplicationDbContext context) => _context = context;

    public ApplicationResponse Get(ApplicationRequest ApplicationRequest) => 
        new ApplicationResponse 
        { 
            Result = "The result of a successful execution.", 
            IsSuccess = true 
        };
}