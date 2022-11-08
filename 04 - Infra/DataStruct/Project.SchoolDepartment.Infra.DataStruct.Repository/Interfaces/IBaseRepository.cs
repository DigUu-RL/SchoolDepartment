﻿using Project.SchoolDepartment.Infra.DataStruct.Repository.Helpers;
using System.Linq.Expressions;

namespace Project.SchoolDepartment.Infra.DataStruct.Repository.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : class
{
	Task<PaginatedList<TEntity>> GetAllAsync(int page, int quantity);
	Task<TEntity?> GetByGuidAsync(Guid guid);
	Task CreateAsync(TEntity entity);
	Task UpdateAsync(TEntity entity);
	Task DeleteAsync(TEntity entity);
}
