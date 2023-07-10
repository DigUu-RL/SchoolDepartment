using Project.SchoolDepartment.Infra.DataStruct.Data.Entities;
using System.Linq.Expressions;

namespace Project.SchoolDepartment.Infra.Specs.Contracts;

public sealed class FalseSpecification<TEntity> : Specification<TEntity> where TEntity : EntityBase
{
	public FalseSpecification()
	{
	}

	public override Expression<Func<TEntity, bool>> ToExpression()
	{
		return (TEntity x) => false;
	}
}
