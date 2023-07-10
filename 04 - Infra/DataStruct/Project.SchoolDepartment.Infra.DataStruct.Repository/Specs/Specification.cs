using Project.SchoolDepartment.Infra.DataStruct.Data.Entities;
using Project.SchoolDepartment.Infra.Specs.Contracts;
using System.Linq.Expressions;

namespace Project.SchoolDepartment.Infra.Specs;

public abstract class Specification<TEntity> where TEntity : EntityBase
{
	public static implicit operator Expression<Func<TEntity, bool>>(Specification<TEntity> specification) => specification.ToExpression();
	public static implicit operator Func<TEntity, bool>(Specification<TEntity> specification) => specification.ToExpression().Compile();

	public abstract Expression<Func<TEntity, bool>> ToExpression();

	public static Specification<TEntity> operator &(Specification<TEntity> left, Specification<TEntity> right)
	{
		return new AndSpecification<TEntity>(left, right);
	}

	public static Specification<TEntity> operator |(Specification<TEntity> left, Specification<TEntity> right)
	{
		return new OrSpecification<TEntity>(left, right);
	}

	public static Specification<TEntity> operator !(Specification<TEntity> specification)
	{
		return new NotSpecification<TEntity>(specification);
	}
}
