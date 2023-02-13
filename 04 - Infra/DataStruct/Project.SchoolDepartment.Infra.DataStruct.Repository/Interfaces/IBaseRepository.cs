using Project.SchoolDepartment.Infra.DataStruct.Repository.Helpers;

namespace Project.SchoolDepartment.Infra.DataStruct.Repository.Interfaces;

public interface IBaseRepository<TEntity> : IUnitOfWork where TEntity : class
{
	Task<PaginatedList<TEntity>> GetAllAsync(int page, int quantity);
	Task<TEntity?> GetByGuidAsync(Guid guid);
	Task CreateOrUpdateAsync(TEntity entity);
	Task CreateAsync(TEntity entity);
	Task UpdateAsync(TEntity entity);
	Task DeleteAsync(TEntity entity);
}
