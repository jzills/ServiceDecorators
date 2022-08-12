namespace ServiceDecorators.Services;

public class ApplicationResponse
{
    public object Result { get; set; }
    public bool IsSuccess { get; set; }
    public bool IsFromCache { get; set; }
}