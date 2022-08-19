using Microsoft.AspNetCore.Http;
using Project.SchoolDepartment.Domain.Helpers;
using Project.SchoolDepartment.Infra.Middleware.Exceptions;
using System.Net;

namespace Project.SchoolDepartment.Infra.Middleware;

public class ErrorMiddleware
{
	private readonly RequestDelegate request;

	public ErrorMiddleware(RequestDelegate request)
	{
		this.request = request;
	}

	public async Task Invoke(HttpContext context)
	{
		try
		{
			await request(context);
		}
		catch (GlobalException ex)
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
		if (statusCode is default(HttpStatusCode))
			statusCode = HttpStatusCode.InternalServerError;

		string result = new { statusCode, errorMessage = ex.Message }.ToJson();

		context.Response.ContentType = "application/json";
		context.Response.StatusCode = statusCode.ToInt32();
		await context.Response.WriteAsync(result);
	}
}
