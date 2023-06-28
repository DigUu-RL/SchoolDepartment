using System.Linq.Expressions;

namespace Project.SchoolDepartment.Infra.Specs.Contracts;

public sealed class AndSpecification<TClass> : Specification<TClass> where TClass : class
{
	private readonly Specification<TClass> _left;
	private readonly Specification<TClass> _right;

	public AndSpecification(Specification<TClass> left, Specification<TClass> right)
	{
		_left = left ?? throw new ArgumentNullException(nameof(left));
		_right = right ?? throw new ArgumentNullException(nameof(right));
	}

	public override Expression<Func<TClass, bool>> ToExpression()
	{
		Expression<Func<TClass, bool>> left = _left.ToExpression();
		Expression<Func<TClass, bool>> right = _right.ToExpression();

		return Expression.Lambda<Func<TClass, bool>>(Expression.AndAlso(left, right));
	}
}
