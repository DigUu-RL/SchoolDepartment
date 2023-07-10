using Project.SchoolDepartment.Infra.DataStruct.Data.Entities;
using System.Linq.Expressions;

namespace Project.SchoolDepartment.Infra.Specs.Contracts;

public sealed class ExpressionSpecification<TEntity> : Specification<TEntity> where TEntity : EntityBase
{
	private readonly Expression<Func<TEntity, bool>> _expression;

	public ExpressionSpecification(Expression<Func<TEntity, bool>> expression)
	{
		_expression = expression ?? throw new ArgumentNullException(nameof(expression));
	}

	public override Expression<Func<TEntity, bool>> ToExpression()
	{
		return _expression;
	}
}
