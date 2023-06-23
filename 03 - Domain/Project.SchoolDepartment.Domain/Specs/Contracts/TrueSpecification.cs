﻿using Project.SchoolDepartment.Domain.Specs.Interfaces;
using System.Linq.Expressions;

namespace Project.SchoolDepartment.Domain.Specs.Contracts;

public sealed class TrueSpecification<TClass> : Specification<TClass> where TClass : class
{
	private readonly ISpecification<TClass> _specification;

	public TrueSpecification(ISpecification<TClass> specification)
	{
		_specification = specification ?? throw new ArgumentNullException(nameof(specification));
	}

	public override Expression<Func<TClass, bool>> ToExpression()
	{
		return (TClass x) => true;
	}
}