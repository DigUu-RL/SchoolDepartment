using System.Linq.Expressions;

namespace Project.SchoolDepartment.Infra.Specs.Abstractions;

public sealed class OrSpecification<T> : Specification<T>
{
	private readonly Specification<T> _left;
	private readonly Specification<T> _right;

	public OrSpecification(Specification<T> left, Specification<T> right)
	{
		_left = left ?? throw new ArgumentNullException(nameof(left));
		_right = right ?? throw new ArgumentNullException(nameof(right));
	}

	public override Expression<Func<T, bool>> ToExpression()
	{
		Expression<Func<T, bool>> left = _left.ToExpression();
		Expression<Func<T, bool>> right = _right.ToExpression();

		return Expression.Lambda<Func<T, bool>>(Expression.OrElse(left.Body, right.Body), right.Parameters);
	}
}
