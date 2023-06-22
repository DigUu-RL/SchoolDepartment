using System.Net;

namespace Project.SchoolDepartment.Infra.Middleware.Exceptions;

public class InvalidDataException : BaseException
{
	public InvalidDataException(string message, HttpStatusCode statusCode) : base(message, statusCode)
	{
	}
}
