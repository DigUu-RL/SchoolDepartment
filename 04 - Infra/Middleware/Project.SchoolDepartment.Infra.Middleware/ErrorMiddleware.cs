using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Project.SchoolDepartment.Infra.Middleware.Exceptions;
using System.Net;

namespace Project.SchoolDepartment.Infra.Middleware;

public class ErrorMiddleware
{
	private readonly RequestDelegate next;

	public ErrorMiddleware(RequestDelegate next)
	{
		this.next = next;
	}

	public async Task InvokeAsync(HttpContext context)
	{
		try
		{
			await next.Invoke(context);
		}
		catch (BaseException ex)
		{
			await HandleExceptionAsync(context, ex, ex.StatusCode);
		}
		catch (Exception ex)
		{
			await HandleExceptionAsync(context, ex);
		}
	}

	private static async Task HandleExceptionAsync(HttpContext context, Exception ex, HttpStatusCode statusCode = default)
	{
		if (ex is not BaseException)
			statusCode = HttpStatusCode.InternalServerError;

		string result = JsonConvert.SerializeObject(new
		{
			statusCode,
			errorName = statusCode.ToString(),
			errorMessage = ex.Message,
			innerException = ex.InnerException?.Message
		});

		context.Response.ContentType = "application/json";
		context.Response.StatusCode = (int) statusCode;

		await context.Response.WriteAsync(result);
	}
}
