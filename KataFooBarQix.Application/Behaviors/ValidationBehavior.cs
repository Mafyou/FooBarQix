namespace KataFooBarQix.Application.Behaviors;

public class ValidationBehavior<T, R> : IPipelineBehavior<T, R>
    where T : IRequest<R>
{
    private readonly IEnumerable<IValidator<T>> _validators;
    public ValidationBehavior(IEnumerable<IValidator<T>> validators) => _validators = validators;

    public async Task<R> Handle(T request, RequestHandlerDelegate<R> next, CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            var it = _validators.GetEnumerator();
            while (it.MoveNext())
            {
                var result = it.Current.Validate(request);
                if (!result.IsValid)
                {
                    throw new Exception(result.ToString());
                }
            }
        }
        return await next();
    }
}