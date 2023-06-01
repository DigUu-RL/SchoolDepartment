using System.Net;

namespace Project.SchoolDepartment.Infra.Middleware.Exceptions;

public class NotFoundException : BaseException
{
	public NotFoundException(string message) : base(message, HttpStatusCode.NotFound)
	{
	}
}
