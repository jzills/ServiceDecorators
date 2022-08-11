// namespace ValidationDecorator.Decorators;

// public interface IComponent
// {

// }

// public interface IValidationHandler<TRequest>
// {
//     public void Validate(TRequest toValidate);
// }

// public interface IValidationDecorator
// {
//     public void Handle();
// }

// public class ValidationDecorator<TRequest> : IValidationDecorator
//     where TRequest : IComponent
// {
//     private readonly IComponent _component;
//     private readonly IValidationHandler<TRequest> _validator;

//     public ValidationDecorator(
//         IComponent component, 
//         IValidationHandler<TRequest> validator
//     )
//     {
//         _component = component;
//         _validator = validator;
//     }

//     public void Handle()
//     {
//         _validator.Validate(_component);
//     }
// }