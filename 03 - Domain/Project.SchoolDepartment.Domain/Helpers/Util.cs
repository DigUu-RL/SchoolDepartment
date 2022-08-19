namespace Project.SchoolDepartment.Domain.Helpers;

public static class Util
{
	public static string RandomString(int length, bool upper = true)
	{
		char[] chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToArray();

		var list = new char[length];

		for (int i = 0; i < length; i++)
		{
			var x = new Random();
			list[i] = chars[x.Next(chars.Length)];
		}

		string result = ShuffleString(new string(list));
		return upper ? result : result.ToLower();
	}

	public static string ShuffleString(string str)
	{
		return new string(str.OrderBy(x => new Random().Next()).ToArray());
	}
}
