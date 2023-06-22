using Project.SchoolDepartment.Domain.Specs.Interfaces;
using System.Linq.Expressions;

namespace Project.SchoolDepartment.Domain.Specs.Contracts;

public sealed class NotSpecification<TClass> : Specification<TClass> where TClass : class
{
	private readonly ISpecification<TClass> _specification;

	public NotSpecification(ISpecification<TClass> specification)
	{
		_specification = specification ?? throw new ArgumentNullException(nameof(specification));
	}

	public override Expression<Func<TClass, bool>> ToExpression()
	{
		Expression<Func<TClass, bool>> expression = _specification.ToExpression();
		return Expression.Lambda<Func<TClass, bool>>(expression, expression.Parameters);
	}
}
