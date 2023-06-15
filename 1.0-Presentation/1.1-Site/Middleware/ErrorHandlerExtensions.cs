using Microsoft.AspNetCore.Builder;

namespace Site.Middleware
{
	public static class ErrorHandlerExtensions
	{
		public static IApplicationBuilder UseMyErrorHandler(this IApplicationBuilder appBuilder)
		{
			return appBuilder.UseMiddleware<ErrorHandler>();
		}
	}

}
