using Project.SchoolDepartment.Infra.DataStruct.Data.Contexts;
using Project.SchoolDepartment.Infra.DataStruct.Data.Entities;
using Project.SchoolDepartment.Infra.DataStruct.Repository.Helpers;
using Project.SchoolDepartment.Infra.DataStruct.Repository.Interfaces;
using Project.SchoolDepartment.Infra.Specs;
using Project.SchoolDepartment.Infra.Specs.Contracts;

namespace Project.SchoolDepartment.Infra.DataStruct.Repository.Repositories;

public class StudentRepository : BaseRepository<Student>, IStudentRepository
{
	public StudentRepository(AppDbContext dbContext) : base(dbContext) { }

	public override async Task<PaginatedList<Student>> GetAsync(int page, int quantity, Specification<Student>? specification = null)
	{
		specification ??= new TrueSpecification<Student>();

		IQueryable<Student> query = Query.Where(specification);

		PaginatedList<Student> data = await PaginatedList<Student>.CreateInstanceAsync(query, page, quantity);
		return data;
	}
}
