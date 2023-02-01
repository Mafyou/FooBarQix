using FluentValidation;

namespace KataFooBarQix.ServicesExtension;

public static class CustomServiceExtension
{
    public static IServiceCollection AddCustomServices(this IServiceCollection services)
    {
        services.AddTransient<GlobalExceptionHandling>();

        var list = new List<Assembly>(AppDomain.CurrentDomain.GetAssemblies())
        {
            typeof(GetComputeHandler).Assembly
        };
        services.AddMediatR(list.ToArray());

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddSingleton<IComputer, KataComputer>();

        services.AddValidatorsFromAssemblies(new List<Assembly>
        {
            typeof(ValidationBehavior<,>).Assembly
        });

        return services;
    }
}