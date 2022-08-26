using Microsoft.EntityFrameworkCore;

namespace Project.SchoolDepartment.Infra.DataStruct.Repository.Helpers;

public sealed class Paginated<T> : List<T>
{
	public int Page { get; }
	public int Pages { get; }
	public int Total { get; }

	private Paginated(int page, int quantity, int total, List<T> items)
	{
		Page = page;
		Pages = (int) Math.Ceiling(total / (double) quantity);
		Total = total;
		AddRange(items);
	}

	public static async Task<Paginated<T>> CreateAsync(IQueryable<T> query, int page, int quantity)
	{
		page = page == 0 ? 1 : page;
		quantity = quantity == 0 ? 10 : quantity;

		int total = await query.CountAsync();

		List<T> items = await query
			.Skip((page - 1) * quantity)
			.Take(quantity)
			.ToListAsync();

		return new Paginated<T>(page, quantity, total, items);
	}
}
