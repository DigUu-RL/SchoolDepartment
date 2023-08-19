using System.Linq.Expressions;

namespace Project.SchoolDepartment.Infra.Specs.Contracts;

public sealed class NotSpecification<T> : Specification<T>
{
	private readonly Specification<T> _specification;

	public NotSpecification(Specification<T> specification)
	{
		_specification = specification ?? throw new ArgumentNullException(nameof(specification));
	}

	public override Expression<Func<T, bool>> ToExpression()
	{
		Expression<Func<T, bool>> expression = _specification.ToExpression();
		return Expression.Lambda<Func<T, bool>>(Expression.Not(expression.Body), expression.Parameters);
	}
}
