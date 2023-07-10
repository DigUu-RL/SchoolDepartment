namespace Project.SchoolDepartment.Domain.Helpers.Extensions;

public static class StringExtensions
{
	public static TEnum ToEnumOrDefault<TEnum>(this string value) where TEnum : struct, Enum
	{
		return Enum.TryParse(value, out TEnum result) ? result : default;
	}
}
