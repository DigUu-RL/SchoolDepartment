using Microsoft.EntityFrameworkCore;

namespace Project.SchoolDepartment.Infra.DataStruct.Repository.Helpers;

public sealed class PaginatedList<T> : List<T>
{
	public int Page { get; }
	public int Pages { get; }
	public int Total { get; }

	private PaginatedList(int page, int quantity, int total, List<T> items)
	{
		Page = page;
		Pages = (int) Math.Ceiling(total / (double) quantity);
		Total = total;
		AddRange(items);
	}

	public static PaginatedList<T> CreateInstance(IEnumerable<T> source, int page, int quantity)
	{
		page = page == 0 ? 1 : page;
		quantity = quantity == 0 ? 10 : quantity;

		int total = source.Count();

		List<T> items = source
			.Skip((page - 1) * quantity)
			.Take(quantity)
			.ToList();

		return new PaginatedList<T>(page, quantity, total, items);
	}

	public static async Task<PaginatedList<T>> CreateInstanceAsync(IEnumerable<T> source, int page, int quantity)
	{
		page = page == 0 ? 1 : page;
		quantity = quantity == 0 ? 10 : quantity;

		IQueryable<T> query = source.AsQueryable();

		int total = await query.CountAsync();

		List<T> items = await query
			.Skip((page - 1) * quantity)
			.Take(quantity)
			.ToListAsync();

		return new PaginatedList<T>(page, quantity, total, items);
	}
}
