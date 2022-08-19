using System.Net;

namespace Project.SchoolDepartment.Infra.Middleware.Exceptions;

[Serializable]
public class GlobalException : Exception
{
	public HttpStatusCode StatusCode { get; set; }

	public GlobalException(string message, HttpStatusCode statusCode) : base(message)
	{
		StatusCode = statusCode;
	}
}
