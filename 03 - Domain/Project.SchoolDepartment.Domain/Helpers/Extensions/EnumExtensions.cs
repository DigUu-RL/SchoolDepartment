namespace Project.SchoolDepartment.Domain.Helpers.Extensions;

public static class EnumExtensions
{
	public static bool IsValid<TEnum>(this Enum @enum) where TEnum : struct, Enum
	{
		IEnumerable<TEnum> enums = Enum.GetNames(typeof(TEnum)).Select(x => x.ToEnumOrDefault<TEnum>()).Where(x => @enum.HasFlag(x));
		return enums.Any();
	}
}
