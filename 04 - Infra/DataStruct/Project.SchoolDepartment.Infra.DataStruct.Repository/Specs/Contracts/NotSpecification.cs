using Project.SchoolDepartment.Infra.DataStruct.Data.Entities;
using System.Linq.Expressions;

namespace Project.SchoolDepartment.Infra.Specs.Contracts;

public sealed class NotSpecification<TEntity> : Specification<TEntity> where TEntity : EntityBase
{
	private readonly Specification<TEntity> _specification;

	public NotSpecification(Specification<TEntity> specification)
	{
		_specification = specification ?? throw new ArgumentNullException(nameof(specification));
	}

	public override Expression<Func<TEntity, bool>> ToExpression()
	{
		Expression<Func<TEntity, bool>> expression = _specification.ToExpression();
		return Expression.Lambda<Func<TEntity, bool>>(expression, expression.Parameters);
	}
}
