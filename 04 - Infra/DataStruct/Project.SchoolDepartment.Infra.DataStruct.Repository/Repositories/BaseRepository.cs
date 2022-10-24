using Microsoft.EntityFrameworkCore;
using Project.SchoolDepartment.Infra.DataStruct.Data.Contexts;
using Project.SchoolDepartment.Infra.DataStruct.Repository.Helpers;
using Project.SchoolDepartment.Infra.DataStruct.Repository.Interfaces;

namespace Project.SchoolDepartment.Infra.DataStruct.Repository.Repositories;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
	private readonly Context _context;

	protected BaseRepository(Context context)
	{
		_context = context;

		Entity = context.Set<TEntity>();
		Queryable = context.Set<TEntity>().AsQueryable<TEntity>();
	}

	protected Context Context { get => _context; }
	protected DbSet<TEntity> Entity { get; }
	protected IQueryable<TEntity> Queryable { get; }

	public abstract Task<Paginated<TEntity>> GetAllAsync(int page, int quantity);

	public virtual async Task<TEntity?> GetByGuidAsync(Guid guid)
	{
		TEntity? data = await _context.FindAsync<TEntity>(guid);
		return data;
	}

	public virtual async Task CreateAsync(TEntity entity)
	{
		_context.Entry(entity).State = EntityState.Added;
		await _context.SaveChangesAsync();
	}

	public virtual async Task UpdateAsync(TEntity entity)
	{
		_context.Update(entity);
		await _context.SaveChangesAsync();
	}

	public virtual async Task DeleteAsync(TEntity entity)
	{
		_context.Remove(entity);
		await _context.SaveChangesAsync();
	}

	public bool Equals(TEntity? other)
	{
		throw new NotImplementedException();
	}
}
