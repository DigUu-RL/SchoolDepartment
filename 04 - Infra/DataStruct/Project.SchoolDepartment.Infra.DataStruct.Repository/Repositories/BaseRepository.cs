using Project.SchoolDepartment.Infra.DataStruct.Data.Contexts;
using Project.SchoolDepartment.Infra.DataStruct.Data.Entities;
using Project.SchoolDepartment.Infra.DataStruct.Repository.Helpers;
using Project.SchoolDepartment.Infra.DataStruct.Repository.Interfaces;

namespace Project.SchoolDepartment.Infra.DataStruct.Repository.Repositories;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : EntityBase
{
	private readonly AppDbContext _dbContext;

	protected BaseRepository(AppDbContext dbContext)
	{
		_dbContext = dbContext;
		Query = dbContext.Set<TEntity>().AsQueryable<TEntity>();
	}

	protected AppDbContext DbContext { get => _dbContext; }
	protected IQueryable<TEntity> Query { get; }

	public abstract Task<PaginatedList<TEntity>> GetAllAsync(int page, int quantity);

	public virtual async Task<TEntity?> GetByGuidAsync(Guid guid)
	{
		TEntity? data = await _dbContext.FindAsync<TEntity>(guid);
		return data;
	}

	public virtual async Task CreateOrUpdateAsync(TEntity entity)
	{
		Task task = await _dbContext.FindAsync(typeof(TEntity), entity.Guid) is null ? CreateAsync(entity) : UpdateAsync(entity);
		await task;
	}

	public virtual async Task CreateAsync(TEntity entity)
	{
		await _dbContext.AddAsync(entity);
	}

	public virtual async Task UpdateAsync(TEntity entity)
	{
		await Task.Run(() => _dbContext.Update(entity));
	}

	public virtual async Task DeleteAsync(TEntity entity)
	{
		await Task.Run(() => _dbContext.Remove(entity));
	}

	public async Task CommitAsync()
	{
		await _dbContext.SaveChangesAsync();
	}

	public Task RollbackAsync()
	{
		return Task.CompletedTask;
	}
}
