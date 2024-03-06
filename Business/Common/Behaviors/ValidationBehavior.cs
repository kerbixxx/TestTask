using FluentValidation;
using MediatR;

namespace Business.Common.Behaviors
{
    //Валидация запросов перед обработкой
    public class ValidationBehavior<TRequest,TResponse> 
        : IPipelineBehavior<TRequest,TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;

        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request); //Создается контекст валидации
            var failures = _validators 
                .Select(v => v.Validate(context))                   //Для каждого валидатора выполняется валидация.
                .SelectMany(result => result.Errors) 
                .Where(failure => failure != null) 
                .ToList();                                          //Все ошибки собираются в failures
            if (failures.Count != 0)
            {
                throw new ValidationException(failures);
            }

            return next();  //Если валидация прошла успешно - передается обработка запроса следующему запросу в цепочке
        }
    }
}
