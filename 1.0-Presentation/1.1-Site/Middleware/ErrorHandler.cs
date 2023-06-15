using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Site.Model;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Site.Middleware
{
	public class ErrorHandler
	{
		private readonly RequestDelegate _next;
		private readonly ILogger _log;

		public ErrorHandler(RequestDelegate next, ILoggerFactory log)
		{
			this._next = next;
			this._log = log.CreateLogger("MyErrorHandler");
		}

		public async Task Invoke(HttpContext httpContext)
		{
			try
			{
				await _next(httpContext);
			}
			catch (Exception ex)
			{
				await HandleErrorAsync(httpContext, ex);
			}
		}

		private async Task HandleErrorAsync(HttpContext context, Exception exception)
		{
			var errorResponse = new ErrorResponse();

			errorResponse.StatusCode = HttpStatusCode.InternalServerError;
			errorResponse.Message = exception.Message;

			_log.LogError($"Error: {exception.Message}");
			_log.LogError($"Stack: {exception.StackTrace}");

			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int)errorResponse.StatusCode;
			await context.Response.WriteAsync(JsonConvert.SerializeObject(errorResponse));
		}
	}


}
