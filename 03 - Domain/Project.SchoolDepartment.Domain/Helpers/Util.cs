using System.Security.Cryptography;
using System.Text;

namespace Project.SchoolDepartment.Domain.Helpers;

public static class Util
{
	public static async Task<string> CreateStringHash(string content)
	{
		return Convert.ToBase64String(await SHA512.Create().ComputeHashAsync(new MemoryStream(Encoding.UTF8.GetBytes(content))));
	}
}
