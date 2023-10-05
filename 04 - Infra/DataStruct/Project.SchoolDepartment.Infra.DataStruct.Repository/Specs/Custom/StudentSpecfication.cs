using Project.SchoolDepartment.Infra.DataStruct.Data.Entities;
using Project.SchoolDepartment.Infra.DataStruct.Data.Enums;
using Project.SchoolDepartment.Infra.Specs;
using Project.SchoolDepartment.Infra.Specs.Abstractions;

namespace Project.SchoolDepartment.Domain.Specs.Custom;

public static class StudentSpecfication
{
	public static Specification<Student> ById(Guid id)
	{
		return new ExpressionSpecification<Student>(x => x.Id == id);
	}

	public static Specification<Student> ByName(string name)
	{
		return new ExpressionSpecification<Student>(x => x.Name.Equals(name));
	}

	public static Specification<Student> ByLastName(string lastName)
	{
		return new ExpressionSpecification<Student>(x => x.LastName.Equals(lastName));
	}

	public static Specification<Student> ByCPF(string cpf)
	{
		return new ExpressionSpecification<Student>(x => x.CPF.Equals(cpf));
	}

	public static Specification<Student> ByRA(string ra)
	{
		return new ExpressionSpecification<Student>(x => x.RA.Equals(ra));
	}

	public static Specification<Student> ByGender(Gender gender)
	{
		return new ExpressionSpecification<Student>(x => x.Gender == gender);
	}

	public static Specification<Student> ByStreet(string street)
	{
		return new ExpressionSpecification<Student>(x => x.Street.Equals(street));
	}

	public static Specification<Student> ByDistrict(string district)
	{
		return new ExpressionSpecification<Student>(x => x.District.Equals(district));
	}

	public static Specification<Student> ByNumber(int number)
	{
		return new ExpressionSpecification<Student>(x => x.Number == number);
	}

	public static Specification<Student> ByCity(string city)
	{
		return new ExpressionSpecification<Student>(x => x.City.Equals(city));
	}

	public static Specification<Student> ByState(string state)
	{
		return new ExpressionSpecification<Student>(x => x.State.Equals(state));
	}
}
