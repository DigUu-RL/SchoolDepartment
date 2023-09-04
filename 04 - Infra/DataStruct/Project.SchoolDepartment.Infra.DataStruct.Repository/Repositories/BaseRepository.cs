using Project.SchoolDepartment.Infra.DataStruct.Data.Contexts;
using Project.SchoolDepartment.Infra.DataStruct.Data.Entities;
using Project.SchoolDepartment.Infra.DataStruct.Repository.Helpers;
using Project.SchoolDepartment.Infra.DataStruct.Repository.Interfaces;
using Project.SchoolDepartment.Infra.Specs;
using Project.SchoolDepartment.Infra.Specs.Contracts;

namespace Project.SchoolDepartment.Infra.DataStruct.Repository.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : EntityBase
{
	private readonly AppDbContext _dbContext;

	protected BaseRepository(AppDbContext dbContext)
	{
		_dbContext = dbContext;
		Query = dbContext.Set<TEntity>().AsQueryable();
	}

	protected IQueryable<TEntity> Query { get; }

	public virtual IQueryable<TEntity> GetAll(Specification<TEntity>? specification = null)
	{
		specification ??= new TrueSpecification<TEntity>();
		return Query.Where(specification);
	}

	public virtual async Task<PaginatedList<TEntity>> GetAsync(int page, int quantity, Specification<TEntity>? specification = null)
	{
		specification ??= new TrueSpecification<TEntity>();
		return await Query.Where(specification).ToPaginatedListAsync(page, quantity);
	}

	public virtual async Task<TEntity?> GetByIdAsync(Guid guid)
	{
		TEntity? data = await _dbContext.FindAsync<TEntity>(guid);
		return data;
	}

	public virtual async Task CreateOrUpdateAsync(TEntity entity)
	{
		Task task = await _dbContext.FindAsync(typeof(TEntity), entity.Id) is null ? CreateAsync(entity) : UpdateAsync(entity);
		await task;
	}

	public virtual async Task CreateAsync(TEntity entity)
	{
		entity.CreateDate = DateTime.UtcNow;
		entity.LastUpdate = DateTime.UtcNow;

		await _dbContext.AddAsync(entity);
	}

	public virtual async Task UpdateAsync(TEntity entity)
	{
		entity.LastUpdate = DateTime.UtcNow;
		await Task.Run(() => _dbContext.Update(entity));
	}

	public virtual async Task DeleteAsync(TEntity entity)
	{
		await Task.Run(() => _dbContext.Remove(entity));
	}

	public async Task SetExcludedAsync(TEntity entity)
	{
		entity.Excluded = true;
		await UpdateAsync(entity);
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
