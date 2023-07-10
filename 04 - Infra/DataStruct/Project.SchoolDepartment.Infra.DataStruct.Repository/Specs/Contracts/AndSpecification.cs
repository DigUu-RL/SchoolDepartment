using Project.SchoolDepartment.Infra.DataStruct.Data.Entities;
using System.Linq.Expressions;

namespace Project.SchoolDepartment.Infra.Specs.Contracts;

public sealed class AndSpecification<TEntity> : Specification<TEntity> where TEntity : EntityBase
{
	private readonly Specification<TEntity> _left;
	private readonly Specification<TEntity> _right;

	public AndSpecification(Specification<TEntity> left, Specification<TEntity> right)
	{
		_left = left ?? throw new ArgumentNullException(nameof(left));
		_right = right ?? throw new ArgumentNullException(nameof(right));
	}

	public override Expression<Func<TEntity, bool>> ToExpression()
	{
		Expression<Func<TEntity, bool>> left = _left.ToExpression();
		Expression<Func<TEntity, bool>> right = _right.ToExpression();

		return Expression.Lambda<Func<TEntity, bool>>(Expression.AndAlso(left, right));
	}
}
