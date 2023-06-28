using Project.SchoolDepartment.Infra.Specs.Contracts;
using System.Linq.Expressions;

namespace Project.SchoolDepartment.Infra.Specs;

public abstract class Specification<TClass> : ISpecification<TClass> where TClass : class
{
	public static implicit operator Expression<Func<TClass, bool>>(Specification<TClass> specification) => specification.ToExpression();
	public static implicit operator Func<TClass, bool>(Specification<TClass> specification) => specification.ToExpression().Compile();

	public abstract Expression<Func<TClass, bool>> ToExpression();

	public static ISpecification<TClass> operator &(Specification<TClass> left, Specification<TClass> right)
	{
		return new AndSpecification<TClass>(left, right);
	}

	public static ISpecification<TClass> operator |(Specification<TClass> left, Specification<TClass> right)
	{
		return new OrSpecification<TClass>(left, right);
	}

	public static ISpecification<TClass> operator !(Specification<TClass> specification)
	{
		return new NotSpecification<TClass>(specification);
	}
}
