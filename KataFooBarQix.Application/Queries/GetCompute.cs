namespace KataFooBarQix.Application.Queries;

public sealed record GetCompute(string ToCompute) : IRequest<string>;