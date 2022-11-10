namespace Project.SchoolDepartment.Infra.DataStruct.Repository.Helpers;

public static class PaginatedListExtensions
{
	public static PaginatedList<TSource> ToPaginatedList<TSource>(this IEnumerable<TSource> source, int page, int quantity)
	{
		return PaginatedList<TSource>.CreateInstance(source, page, quantity);
	}

	public static async Task<PaginatedList<TSource>> ToPaginatedListAsync<TSource>(this IEnumerable<TSource> source, int page, int quantity)
	{
		return await PaginatedList<TSource>.CreateInstanceAsync(source, page, quantity);
	}
}
