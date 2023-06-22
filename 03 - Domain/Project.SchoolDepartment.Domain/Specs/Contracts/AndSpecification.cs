using Project.SchoolDepartment.Domain.Specs.Interfaces;
using System.Linq.Expressions;

namespace Project.SchoolDepartment.Domain.Specs.Contracts;

public sealed class AndSpecification<TClass> : Specification<TClass> where TClass : class
{
	private readonly ISpecification<TClass> _left;
	private readonly ISpecification<TClass> _right;

	public AndSpecification(ISpecification<TClass> left, ISpecification<TClass> right)
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
