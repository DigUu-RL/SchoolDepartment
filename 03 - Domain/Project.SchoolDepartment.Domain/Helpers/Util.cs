using System.Security.Cryptography;
using System.Text;

namespace Project.SchoolDepartment.Domain.Helpers;

public static class Util
{
	private static readonly Random _random = new();

	public static async Task<string> CreateStringHashAsync(string content)
	{
		return Convert.ToBase64String(await SHA512.Create().ComputeHashAsync(new MemoryStream(Encoding.UTF8.GetBytes(content))));
	}

	public static string RandomString(int length)
	{
		char[] chars = ("ABCDEFGHIJKLMNOPQRSTUVWXYZ" + "abcdefghijklmnopqrstuvwxyz" + "1234567890").ToArray();

		var builder = new StringBuilder();

		for (int i = 0; i < length; i++)
		{
			int x = _random.Next(chars.Length);
			builder.Append(chars[x]);
		}

		string result = builder.ToString();
		return ShuffleString(result);
	}

	public static string ShuffleString(string value)
	{
		return new string(value.OrderBy(x => _random.Next()).ToArray());
	}
}
