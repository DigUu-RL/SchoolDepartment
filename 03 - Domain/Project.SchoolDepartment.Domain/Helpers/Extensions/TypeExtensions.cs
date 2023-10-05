using Project.SchoolDepartment.Infra.Middleware.Attributes;

namespace Project.SchoolDepartment.Domain.Helpers.Extensions;

public static class TypeExtensions
{
	public static bool IsDTO(this Type type)
	{
		return type.GetCustomAttributes(typeof(DTOAttribute), false).Any();
	}

	public static bool IsModel(this Type type)
	{
		return type.GetCustomAttributes(typeof(ModelAttribute), false).Any();
	}

	public static bool IsRequest(this Type type)
	{
		return type.GetCustomAttributes(typeof(RequestAttribute), false).Any();
	}
}
