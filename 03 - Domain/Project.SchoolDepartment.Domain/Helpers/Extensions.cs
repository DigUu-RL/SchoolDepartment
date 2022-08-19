using Newtonsoft.Json;

namespace Project.SchoolDepartment.Domain.Helpers;

public static class Extensions
{
	#region OBJECT EXTENSIONS

	public static string ToJson(this object obj)
	{
		return JsonConvert.SerializeObject(obj);
	}

	#endregion

	#region ENUM EXTENSIONS

	public static int ToInt32<TEnum>(this TEnum e) where TEnum : struct, Enum
	{
		return Convert.ToInt32(e);
	}

	#endregion
}
