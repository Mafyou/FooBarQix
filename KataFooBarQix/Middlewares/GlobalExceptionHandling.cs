using System.Net;

namespace KataFooBarQix.Middlewares;

public class GlobalExceptionHandling : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
		try
		{
			await next(context);
		}
		catch (Exception ex)
		{
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
			var problem = new ProblemDetails
			{
				Title = ex.Message,
				Detail = ex.InnerException?.Message,
				Status = (int)HttpStatusCode.InternalServerError
			};
			context.Response.ContentType = "application/json";
			await context.Response.WriteAsJsonAsync(problem);
		}
    }
}