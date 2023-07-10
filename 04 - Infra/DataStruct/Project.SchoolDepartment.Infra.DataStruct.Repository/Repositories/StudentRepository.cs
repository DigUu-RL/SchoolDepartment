using Microsoft.EntityFrameworkCore;
using Project.SchoolDepartment.Infra.DataStruct.Data.Contexts;
using Project.SchoolDepartment.Infra.DataStruct.Data.Entities;
using Project.SchoolDepartment.Infra.DataStruct.Repository.Helpers;
using Project.SchoolDepartment.Infra.DataStruct.Repository.Interfaces;
using Project.SchoolDepartment.Infra.Specs;

namespace Project.SchoolDepartment.Infra.DataStruct.Repository.Repositories;

public class StudentRepository : BaseRepository<Student>, IStudentRepository
{
	public StudentRepository(AppDbContext dbContext) : base(dbContext) { }

	public override async Task<PaginatedList<Student>> GetAllAsync(int page, int quantity, Specification<Student>? specification = null)
	{
		IQueryable<Student> query = Query.Include(x => x.Cellphones);

		PaginatedList<Student> data = await PaginatedList<Student>.CreateInstanceAsync(query, page, quantity);
		return data;
	}
}
