using Project.SchoolDepartment.Infra.DataStruct.Data.Entities;
using Project.SchoolDepartment.Infra.DataStruct.Repository.Helpers;
using Project.SchoolDepartment.Infra.Specs;

namespace Project.SchoolDepartment.Infra.DataStruct.Repository.Interfaces;

public interface IBaseRepository<TEntity> : IUnitOfWork where TEntity : EntityBase
{
	Task<PaginatedList<TEntity>> GetAsync(int page, int quantity, Specification<TEntity>? specification = null);
	Task<TEntity?> GetByIdAsync(Guid guid);
	Task CreateOrUpdateAsync(TEntity entity);
	Task CreateAsync(TEntity entity);
	Task UpdateAsync(TEntity entity);
	Task DeleteAsync(TEntity entity);
	Task SetExcludedAsync(TEntity entity);
}
