using System.Linq.Expressions;

namespace Project.SchoolDepartment.Domain.Specs.Interfaces;

public interface ISpecification<TClass> where TClass : class
{
	Expression<Func<TClass, bool>> ToExpression();
}
