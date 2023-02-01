namespace KataFooBarQix.Application.Handlers;

public sealed class GetComputeHandler : IRequestHandler<GetCompute, string>
{
    private readonly IComputer _compute;

    public GetComputeHandler(IComputer compute)
    {
        _compute = compute;
    }
    public async Task<string> Handle(GetCompute request, CancellationToken cancellationToken)
    {
        return _compute.Compute(request.ToCompute);
    }
}

public sealed class GetComputeValidator : AbstractValidator<GetCompute>
{
    public GetComputeValidator()
    {
        RuleFor(i => i.ToCompute)
            .Must(validateNumber)
            .WithMessage("Invalid number");
    }
    private bool validateNumber(string input)
    {
        return int.TryParse(input, out var _);
    }
}