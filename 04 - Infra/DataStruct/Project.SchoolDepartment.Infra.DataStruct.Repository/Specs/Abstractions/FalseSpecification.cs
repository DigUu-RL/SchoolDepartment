﻿using System.Linq.Expressions;

namespace Project.SchoolDepartment.Infra.Specs.Abstractions;

public sealed class FalseSpecification<T> : Specification<T>
{
	public FalseSpecification()
	{
	}

	public override Expression<Func<T, bool>> ToExpression()
	{
		return (T x) => false;
	}
}
