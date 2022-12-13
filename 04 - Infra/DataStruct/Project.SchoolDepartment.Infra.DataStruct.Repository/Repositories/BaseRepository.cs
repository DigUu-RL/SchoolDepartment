using Microsoft.EntityFrameworkCore;
using Project.SchoolDepartment.Infra.DataStruct.Data.Contexts;
using Project.SchoolDepartment.Infra.DataStruct.Data.Entities;
using Project.SchoolDepartment.Infra.DataStruct.Repository.Helpers;
using Project.SchoolDepartment.Infra.DataStruct.Repository.Interfaces;

namespace Project.SchoolDepartment.Infra.DataStruct.Repository.Repositories;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : EntityBase
{
	private readonly Context _context;

	protected BaseRepository(Context context)
	{
		_context = context;
		Queryable = context.Set<TEntity>().AsQueryable<TEntity>();
	}

	protected Context Context { get => _context; }
	protected IQueryable<TEntity> Queryable { get; }

	public abstract Task<PaginatedList<TEntity>> GetAllAsync(int page, int quantity);

	public virtual async Task<TEntity?> GetByGuidAsync(Guid guid)
	{
		TEntity? data = await _context.FindAsync<TEntity>(guid);
		return data;
	}

	public virtual async Task CreateOrUpdateAsync(TEntity entity)
	{
		if (await _context.FindAsync(typeof(TEntity), entity.Guid) is not TEntity)
		{
			await CreateAsync(entity);
		}
		else
		{
			await UpdateAsync(entity);
		}
	}

	public virtual async Task CreateAsync(TEntity entity)
	{
		await Task.Run(() => _context.Entry(entity).State = EntityState.Added);
	}

	public virtual async Task UpdateAsync(TEntity entity)
	{
		await Task.Run(() => _context.Update(entity));
	}

	public virtual async Task DeleteAsync(TEntity entity)
	{
		await Task.Run(() => _context.Remove(entity));
	}

	public async Task<bool> CommitAsync()
	{
		return await _context.SaveChangesAsync() > 0;
	}

	public Task RollbackAsync()
	{
		return Task.CompletedTask;
	}
}
