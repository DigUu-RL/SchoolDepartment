using System.Linq.Expressions;

namespace Project.SchoolDepartment.Domain.Specs.Contracts;

public sealed class ExpressionSpecification<TClass> : Specification<TClass> where TClass : class
{
	private readonly Expression<Func<TClass, bool>> _expression;

	public ExpressionSpecification(Expression<Func<TClass, bool>> expression)
	{
		_expression = expression ?? throw new ArgumentNullException(nameof(expression));
	}

	public override Expression<Func<TClass, bool>> ToExpression()
	{
		return _expression;
	}
}
