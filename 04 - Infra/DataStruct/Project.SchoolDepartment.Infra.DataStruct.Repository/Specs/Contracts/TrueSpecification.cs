using Project.SchoolDepartment.Infra.DataStruct.Data.Entities;
using System.Linq.Expressions;

namespace Project.SchoolDepartment.Infra.Specs.Contracts;

public sealed class TrueSpecification<TEntity> : Specification<TEntity> where TEntity : EntityBase
{
	public TrueSpecification()
	{
	}

	public override Expression<Func<TEntity, bool>> ToExpression()
	{
		return (TEntity x) => true;
	}
}
