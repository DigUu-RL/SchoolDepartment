using System.Net;

namespace Project.SchoolDepartment.Infra.Middleware.Exceptions;

public class RequiredDataException : BaseException
{
	public RequiredDataException(string message, HttpStatusCode statusCode) : base(message, statusCode)
	{

	}
}
