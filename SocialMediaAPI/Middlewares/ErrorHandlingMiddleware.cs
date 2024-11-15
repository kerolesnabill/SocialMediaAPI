using SocialMediaDomain.Exceptions;

namespace SocialMediaAPI.Middlewares;

public class ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (NotFoundException ex)
        {
            logger.LogWarning(ex.Message);

            context.Response.StatusCode = 404;
            await context.Response.WriteAsJsonAsync(new { error = ex.Message });
        }
        catch (ForbidException ex)
        {
            logger.LogWarning("Access forbid {Ex}", ex);

            context.Response.StatusCode = 403;
            await context.Response.WriteAsJsonAsync(new { error = "Access forbid" });
        }
        catch (IncorrectException ex)
        {
            logger.LogWarning(ex.Message);

            context.Response.StatusCode = 404;
            await context.Response.WriteAsJsonAsync(new { error = ex.Message });
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message, ex);

            context.Response.StatusCode = 500;
            await context.Response.WriteAsJsonAsync(new { error = "Something went wrong" });
        }
    }
}
