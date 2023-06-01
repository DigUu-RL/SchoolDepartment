using System.Net;

namespace Project.SchoolDepartment.Infra.Middleware.Exceptions;

[Serializable]
public abstract class BaseException : Exception
{
	public HttpStatusCode StatusCode { get; }

	protected BaseException(string message, HttpStatusCode statusCode) : base(message)
	{
		StatusCode = statusCode;
	}
}
