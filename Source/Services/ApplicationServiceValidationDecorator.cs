using System;
using System.Collections.Generic;

namespace ServiceDecorators.Services;

public class ApplicationServiceValidationDecorator : IApplicationService
{
    private readonly IApplicationService _service;

    public ApplicationServiceValidationDecorator(IApplicationService service) => _service = service;

    public ApplicationResponse Get(ApplicationRequest request)
    {
        if (request == null) throw new ArgumentNullException($"The {nameof(ApplicationRequest)} cannot be null.");

        List<Exception> exceptions = new();

        if (string.IsNullOrEmpty(request.Code))
        {
            exceptions.Add(new ArgumentException(
                $"The {nameof(ApplicationRequest)} cannot have an empty code."
            ));
        }

        if (request.Date.Year < DateTime.Now.Year)
        {
            exceptions.Add(new ArgumentException(
                $"The {nameof(ApplicationRequest)} cannot have a date with a year prior to this year."
            ));
        }

        if (exceptions.Count >= 1)
        {
            throw new AggregateException(
                $"One or more errors occurred with {nameof(ApplicationRequest)}", 
                exceptions
            );
        }
 
        return _service.Get(request);
    }
}