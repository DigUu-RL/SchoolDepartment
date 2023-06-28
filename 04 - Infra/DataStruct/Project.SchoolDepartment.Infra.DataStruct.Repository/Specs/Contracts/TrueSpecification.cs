using System.Linq.Expressions;

namespace Project.SchoolDepartment.Infra.Specs.Contracts;

public sealed class TrueSpecification<TClass> : Specification<TClass> where TClass : class
{
	public TrueSpecification()
	{
	}

	public override Expression<Func<TClass, bool>> ToExpression()
	{
		return (TClass x) => true;
	}
}
